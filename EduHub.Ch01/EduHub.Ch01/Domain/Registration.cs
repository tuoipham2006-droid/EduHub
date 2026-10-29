namespace EduHub.Ch01.Domain;

/// <summary>
/// Lưu thông tin đăng ký tham gia sự kiện.
/// </summary>
public class Registration
{
    /// <summary>
    /// Trạng thái chờ xác nhận.
    /// </summary>
    public const string PendingStatus = "Pending";

    /// <summary>
    /// Trạng thái đã xác nhận.
    /// </summary>
    public const string ConfirmedStatus = "Confirmed";

    /// <summary>
    /// Trạng thái đã hủy.
    /// </summary>
    public const string CancelledStatus = "Cancelled";

    /// <summary>
    /// Mã đăng ký.
    /// </summary>
    public Guid Id { get; private set; }

    /// <summary>
    /// Mã thành viên.
    /// </summary>
    public Guid MemberId { get; private set; }

    /// <summary>
    /// Mã sự kiện.
    /// </summary>
    public Guid EventId { get; private set; }

    /// <summary>
    /// Ngày giờ đăng ký.
    /// </summary>
    public DateTime RegisteredAt { get; private set; }

    /// <summary>
    /// Trạng thái đăng ký.
    /// </summary>
    public string Status { get; private set; }

    // Constructor private.
    private Registration(
        Guid id,
        Guid memberId,
        Guid eventId,
        DateTime registeredAt,
        string status)
    {
        Id = id;
        MemberId = memberId;
        EventId = eventId;
        RegisteredAt = registeredAt;
        Status = status;
    }

    /// <summary>
    /// Tạo đăng ký mới với trạng thái Pending.
    /// </summary>
    public static Registration Create(
        Guid memberId,
        Guid eventId)
    {
        if (memberId == Guid.Empty)
        {
            throw new ArgumentException("Member ID is invalid.");
        }

        if (eventId == Guid.Empty)
        {
            throw new ArgumentException("Event ID is invalid.");
        }

        Registration registration = new Registration(
            Guid.NewGuid(),
            memberId,
            eventId,
            DateTime.Now,
            PendingStatus);

        return registration;
    }

    /// <summary>
    /// Xác nhận đăng ký.
    /// </summary>
    public void Confirm()
    {
        if (Status != PendingStatus)
        {
            throw new InvalidOperationException(
                "Only pending registrations can be confirmed.");
        }

        Status = ConfirmedStatus;
    }

    /// <summary>
    /// Hủy đăng ký.
    /// </summary>
    public void Cancel()
    {
        if (Status == CancelledStatus)
        {
            throw new InvalidOperationException(
                "This registration has already been cancelled.");
        }

        Status = CancelledStatus;
    }
}