namespace EduHub.Ch01.Domain;

/// <summary>
/// Lưu thông tin thành viên câu lạc bộ.
/// </summary>
public class Member
{
    /// <summary>
    /// Mã thành viên.
    /// </summary>
    public Guid Id { get; private set; }

    /// <summary>
    /// Họ tên thành viên.
    /// </summary>
    public string Name { get; private set; }

    /// <summary>
    /// Email thành viên.
    /// </summary>
    public string Email { get; private set; }

    /// <summary>
    /// Mã số sinh viên.
    /// </summary>
    public string StudentCode { get; private set; }

    /// <summary>
    /// Ngày tham gia câu lạc bộ.
    /// </summary>
    public DateTime JoinedAt { get; private set; }

    // Constructor private để tạo đối tượng thông qua Create().
    private Member(
        Guid id,
        string name,
        string email,
        string studentCode,
        DateTime joinedAt)
    {
        Id = id;
        Name = name;
        Email = email;
        StudentCode = studentCode;
        JoinedAt = joinedAt;
    }

    /// <summary>
    /// Tạo thành viên mới.
    /// </summary>
    public static Member Create(
        string name,
        string email,
        string studentCode)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            throw new ArgumentException("Name cannot be empty.");
        }

        if (string.IsNullOrWhiteSpace(email) ||
            !email.Contains('@'))
        {
            throw new ArgumentException("Email is invalid.");
        }

        if (string.IsNullOrWhiteSpace(studentCode))
        {
            throw new ArgumentException("Student code cannot be empty.");
        }

        Member member = new Member(
            Guid.NewGuid(),
            name.Trim(),
            email.Trim(),
            studentCode.Trim(),
            DateTime.Now);

        return member;
    }

    /// <summary>
    /// Kiểm tra thành viên có đang hoạt động hay không.
    /// </summary>
    public bool IsActive()
    {
        if (JoinedAt <= DateTime.Now)
        {
            return true;
        }

        return false;
    }
}