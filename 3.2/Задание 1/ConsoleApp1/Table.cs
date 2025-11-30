class Table(int id, string location, int seats)
{
    public int Id { get; private set; } = id;
    public string Location { get; private set; } = location;
    public int Seats { get; private set; } = seats;
    public Dictionary<string, Booking> Schedule { get; private set; } = [];

    public void Update(string location, int seats)
    {
        Location = location;
        Seats = seats;
    }

    public bool AddReservation(string time, Booking booking)
    {
        if (Schedule.ContainsKey(time))
        {
            Console.WriteLine($"Время {time} уже занято.");
            return false;
        }

        Schedule[time] = booking;
        return true;
    }

    public void RemoveReservation(string time)
    {
        if (Schedule.ContainsKey(time))
        {
            Schedule.Remove(time);
        }
        else
        {
            Console.WriteLine($"Бронь на время {time} не найдена");
        }
    }

    public void Display()
    {
        Console.WriteLine($"ID: {Id.ToString().PadLeft(60, '-')}");
        Console.WriteLine($"Расположение: {Location.PadLeft(60, '-')}");
        Console.WriteLine($"Количество мест: {Seats.ToString().PadLeft(60, '-')}");
        Console.WriteLine("Расписание:");

        for (int hour = 9; hour < 18; hour++)
        {
            string timeSlot = $"{hour:00}:00-{hour + 1:00}:00";
            if (Schedule.ContainsKey(timeSlot))
            {
                var booking = Schedule[timeSlot];
                Console.WriteLine($"{timeSlot.PadRight(60, '-')} ID {booking.ClientId}, {booking.ClientName}, {booking.ClientPhone}");
            }
            else
            {
                Console.WriteLine($"{timeSlot.PadRight(60, '-')}");
            }
        }
    }
}

