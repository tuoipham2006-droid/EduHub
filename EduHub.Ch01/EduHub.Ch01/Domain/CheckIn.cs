namespace EduHub.Ch01.Domain;

/// <summary>
/// Lưu thông tin điểm danh của người tham gia sự kiện.
/// </summary>
public class CheckIn
{
    /// <summary>
    /// Phương thức điểm danh bằng QR.
    /// </summary>
    public const string QrMethod = "QR";

    /// <summary>
    /// Phương thức điểm danh thủ công.
    /// </summary>
    public const string ManualMethod = "Manual";

    /// <summary>
    /// Mã check-in.
    /// </summary>
    public Guid Id { get; private set; }

    /// <summary>
    /// Mã đăng ký của người tham gia.
    /// </summary>
    public Guid RegistrationId { get; private set; }

    /// <summary>
    /// Thời gian điểm danh.
    /// </summary>
    public DateTime CheckedInAt { get; private set; }

    /// <summary>
    /// Phương thức điểm danh.
    /// </summary>
    public string Method { get; private set; }

    // Constructor private.
    private CheckIn(
        Guid id,
        Guid registrationId,
        DateTime checkedInAt,
        string method)
    {
        Id = id;
        RegistrationId = registrationId;
        CheckedInAt = checkedInAt;
        Method = method;
    }

    /// <summary>
    /// Tạo bản ghi check-in mới.
    /// </summary>
    public static CheckIn Create(
        Guid registrationId,
        string method)
    {
        if (registrationId == Guid.Empty)
        {
            throw new ArgumentException(
                "Registration ID is invalid.");
        }

        if (method != QrMethod && method != ManualMethod)
        {
            throw new ArgumentException(
                "Check-in method is invalid.");
        }

        CheckIn checkIn = new CheckIn(
            Guid.NewGuid(),
            registrationId,
            DateTime.Now,
            method);

        return checkIn;
    }

    /// <summary>
    /// Trả về nội dung mô tả lần check-in.
    /// </summary>
    public string Summary()
    {
        string result = "Check-in at ";
        result += CheckedInAt.ToString("dd/MM/yyyy HH:mm");
        result += " by ";
        result += Method;

        return result;
    }
}