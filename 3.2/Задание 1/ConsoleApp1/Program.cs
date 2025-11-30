List<Table> tables = [];
List<Booking> bookings = [];

tables.Add(new Table(1, "у окна", 4));
tables.Add(new Table(2, "у прохода", 2));
tables.Add(new Table(3, "в глубине", 6));

bookings.Add(new Booking(1, "Макс", "88005553535", "12:00", "13:00", "День рождения", tables[0]));
bookings.Add(new Booking(2, "Анна", "5745552377", "16:00", "17:00", "Деловая встреча", tables[1]));

while (true)
{
    Console.WriteLine("\nМеню:");
    Console.WriteLine("1. Создать набор столов");
    Console.WriteLine("2. Создать набор бронирований");
    Console.WriteLine("3. Редактировать информацию о столе");
    Console.WriteLine("4. Вывести информацию о столе по ID");
    Console.WriteLine("5. Вывести перечень всех доступных столов");
    Console.WriteLine("6. Вывести перечень всех бронирований");
    Console.WriteLine("7. Найти бронирование по номеру телефона и имени клиента");
    Console.WriteLine("8. Выход");
    Console.Write("Выберите действие: ");
    string choice = Console.ReadLine();

    switch (choice)
    {
        case "1":
            CreateTables();
            break;
        case "2":
            CreateBookings();
            break;
        case "3":
            EditTable();
            break;
        case "4":
            DisplayTableById();
            break;
        case "5":
            DisplayAvailableTables();
            break;
        case "6":
            DisplayAllBookings();
            break;
        case "7":
            SearchBooking();
            break;
        case "8":
            return;
        default:
            Console.WriteLine("Такого действия нет, попробуйте снова");
            break;
    }
}

void CreateTables()
{
    Console.Write("Введите количество столов: ");
    int n = Convert.ToInt32(Console.ReadLine());

    for (int i = 0; i < n; i++)
    {
        int id = tables.Count + 1;
        Console.WriteLine($"Введите данные для стола {id}:");
        Console.Write("Расположение: ");
        string location = Console.ReadLine();
        Console.Write("Количество мест: ");
        int seats = Convert.ToInt32(Console.ReadLine());

        tables.Add(new Table(id, location, seats));
        Console.WriteLine($"Стол с ID {id} успешно добавлен");
    }
}

void CreateBookings()
{
    Console.Write("Введите количество бронирований: ");
    int n = Convert.ToInt32(Console.ReadLine());

    for (int i = 0; i < n; i++)
    {
        int id = bookings.Count + 1;
        Console.WriteLine($"Введите данные для бронирования {id}:");
        Console.Write("Имя клиента: ");
        string clientName = Console.ReadLine();
        Console.Write("Номер телефона клиента: ");
        string clientPhone = Console.ReadLine();
        Console.Write("Начало брони (hh:mm): ");
        string bookingStart = Console.ReadLine();
        Console.Write("Конец брони (hh:mm): ");
        string bookingEnd = Console.ReadLine();
        Console.Write("Комментарий: ");
        string comment = Console.ReadLine();
        Console.Write("ID стола: ");
        int tableId = Convert.ToInt32(Console.ReadLine());

        Table table = tables.Find(t => t.Id == tableId);
        if (table != null)
        {
            try
            {
                bookings.Add(new Booking(id, clientName, clientPhone, bookingStart, bookingEnd, comment, table));
                Console.WriteLine($"Бронь с ID {id} успешно добавлена");
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                continue;
            }
        }
        else
        {
            Console.WriteLine($"Стол с ID {tableId} не найден");
        }
    }
}

void EditTable()
{
    Console.Write("Введите ID стола для редактирования: ");
    int tableId = Convert.ToInt32(Console.ReadLine());

    Table table = tables.Find(t => t.Id == tableId);
    if (table != null)
    {
        bool isTableInUse = bookings.Exists(b => b.AssignedTable.Id == tableId);
        if (isTableInUse)
        {
            Console.WriteLine("Невозможно редактировать стол, так как он используется в активных бронированиях");
            return;
        }

        Console.Write("Новое расположение: ");
        string newLocation = Console.ReadLine();
        Console.Write("Новое количество мест: ");
        int newSeats = Convert.ToInt32(Console.ReadLine());

        try
        {
            table.Update(newLocation, newSeats);
            Console.WriteLine("Информация о столе успешно обновлена");
        }catch(Exception ex)
        {
            Console.WriteLine(ex.Message);
            return;
        }
    }
    else
    {
        Console.WriteLine($"Стол с ID {tableId} не найден");
    }
}

void DisplayTableById()
{
    Console.Write("Введите ID стола: ");
    int tableId = Convert.ToInt32(Console.ReadLine());

    Table table = tables.Find(t => t.Id == tableId);
    if (table != null)
    {
        table.Display();
    }
    else
    {
        Console.WriteLine($"Стол с ID {tableId} не найден");
    }
}

void DisplayAvailableTables()
{
    Console.WriteLine("\nВведите фильтр для поиска доступных столов:");
    Console.Write("Минимальное количество мест: ");
    int minSeats = Convert.ToInt32(Console.ReadLine());
    Console.Write("Введите время начала бронирования (hh:mm): ");
    string bookingStart = Console.ReadLine();
    Console.Write("Введите время окончания бронирования (hh:mm): ");
    string bookingEnd = Console.ReadLine();

    TimeSpan start = TimeSpan.Parse(bookingStart);
    TimeSpan end = TimeSpan.Parse(bookingEnd);

    Console.WriteLine("\nДоступные столы:");
    foreach (var table in tables)
    {
        if (table.Seats >= minSeats && IsTableAvailable(table, start, end))
        {
            table.Display();
            Console.WriteLine();
        }
    }
}

bool IsTableAvailable(Table table, TimeSpan start, TimeSpan end)
{
    for (TimeSpan time = start; time < end; time = time.Add(TimeSpan.FromHours(1)))
    {
        string timeSlot = $"{time:hh\\:mm}-{time.Add(TimeSpan.FromHours(1)):hh\\:mm}";
        if (table.Schedule.ContainsKey(timeSlot))
        {
            return false;
        }
    }
    return true;
}

void DisplayAllBookings()
{
    Console.WriteLine("\nВсе бронирования:");
    foreach (var booking in bookings)
    {
        Console.WriteLine($"Имя: {booking.ClientName}, Телефон: {booking.ClientPhone}, ID столика: {booking.AssignedTable.Id}, Время: {booking.BookingStart}-{booking.BookingEnd}");
    }
}

void SearchBooking()
{
    Console.Write("\nВведите последние 4 цифры номера телефона: ");
    string phoneSuffix = Console.ReadLine();
    Console.Write("Введите имя клиента: ");
    string clientName = Console.ReadLine();

    Console.WriteLine("\nРезультаты поиска:");
    foreach (var booking in bookings)
    {
        if (booking.ClientPhone.EndsWith(phoneSuffix) && booking.ClientName.Equals(clientName, StringComparison.OrdinalIgnoreCase))
        {
            Console.WriteLine($"Имя: {booking.ClientName}, Телефон: {booking.ClientPhone}, ID столика: {booking.AssignedTable.Id}, Время: {booking.BookingStart}-{booking.BookingEnd}");
        }
    }
}