class Booking
{
    public int ClientId { get; private set; }
    public string ClientName { get; private set; }
    public string ClientPhone { get; private set; }
    public string BookingStart { get; private set; }
    public string BookingEnd { get; private set; }
    public string Comment { get; private set; }
    public Table AssignedTable { get; private set; }

    public Booking(int clientId, string clientName, string clientPhone, string bookingStart, string bookingEnd, string comment, Table table)
    {
        ClientId = clientId;
        ClientName = clientName;
        ClientPhone = clientPhone;
        BookingStart = bookingStart;
        BookingEnd = bookingEnd;
        Comment = comment;
        AssignedTable = table;

        TimeSpan start = TimeSpan.Parse(bookingStart);
        TimeSpan end = TimeSpan.Parse(bookingEnd);

        for (TimeSpan time = start; time < end; time = time.Add(TimeSpan.FromHours(1)))
        {
            string timeSlot = $"{time:hh\\:mm}-{time.Add(TimeSpan.FromHours(1)):hh\\:mm}";
            if (!AssignedTable.AddReservation(timeSlot, this))
            {
                throw new Exception($"Не удалось забронировать стол на время {timeSlot}");
            }
        }
    }

    public void Update(string bookingStart, string bookingEnd, string comment)
    {
        AssignedTable.RemoveReservation($"{BookingStart}-{BookingEnd}");

        BookingStart = bookingStart;
        BookingEnd = bookingEnd;
        Comment = comment;

        if (!AssignedTable.AddReservation($"{BookingStart}-{BookingEnd}", this))
        {
            throw new Exception("Не удалось изменить бронь");
        }
    }

    public void Cancel()
    {
        TimeSpan start = TimeSpan.Parse(BookingStart);
        TimeSpan end = TimeSpan.Parse(BookingEnd);

        for (TimeSpan time = start; time < end; time = time.Add(TimeSpan.FromHours(1)))
        {
            string timeSlot = $"{time:hh\\:mm}-{time.Add(TimeSpan.FromHours(1)):hh\\:mm}";
            AssignedTable.RemoveReservation(timeSlot);
        }

        Console.WriteLine($"Бронь {ClientName} отменена");
    }
}