namespace EduHub.Ch01.Domain;

/// <summary>
/// Lưu thông tin sự kiện của câu lạc bộ.
/// </summary>
public class Event
{
    /// <summary>
    /// Mã sự kiện.
    /// </summary>
    public Guid Id { get; private set; }

    /// <summary>
    /// Mã câu lạc bộ tổ chức sự kiện.
    /// </summary>
    public Guid ClubId { get; private set; }

    /// <summary>
    /// Tên sự kiện.
    /// </summary>
    public string Title { get; private set; }

    /// <summary>
    /// Ngày giờ tổ chức sự kiện.
    /// </summary>
    public DateTime Date { get; private set; }

    /// <summary>
    /// Sức chứa tối đa của sự kiện.
    /// </summary>
    public int Capacity { get; private set; }

    /// <summary>
    /// Sự kiện có tổ chức trực tuyến hay không.
    /// </summary>
    public bool IsOnline { get; private set; }

    // Constructor private.
    private Event(
        Guid id,
        Guid clubId,
        string title,
        DateTime date,
        int capacity,
        bool isOnline)
    {
        Id = id;
        ClubId = clubId;
        Title = title;
        Date = date;
        Capacity = capacity;
        IsOnline = isOnline;
    }

    /// <summary>
    /// Tạo sự kiện mới.
    /// </summary>
    public static Event Create(
        Guid clubId,
        string title,
        DateTime date,
        int capacity,
        bool isOnline)
    {
        if (clubId == Guid.Empty)
        {
            throw new ArgumentException("Club ID is invalid.");
        }

        if (string.IsNullOrWhiteSpace(title))
        {
            throw new ArgumentException("Event title cannot be empty.");
        }

        if (date <= DateTime.Now)
        {
            throw new ArgumentException("Event date must be in the future.");
        }

        if (capacity <= 0)
        {
            throw new ArgumentException(
                "Capacity must be greater than zero.");
        }

        Event newEvent = new Event(
            Guid.NewGuid(),
            clubId,
            title.Trim(),
            date,
            capacity,
            isOnline);

        return newEvent;
    }

    /// <summary>
    /// Kiểm tra sự kiện còn chỗ đăng ký hay không.
    /// </summary>
    public bool HasCapacity(int registeredCount)
    {
        if (registeredCount < 0)
        {
            throw new ArgumentException(
                "Registered count cannot be negative.");
        }

        if (registeredCount < Capacity)
        {
            return true;
        }

        return false;
    }
}