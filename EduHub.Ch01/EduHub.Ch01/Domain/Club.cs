namespace EduHub.Ch01.Domain;

/// <summary>
/// Lưu thông tin câu lạc bộ.
/// </summary>
public class Club
{
    /// <summary>
    /// Mã câu lạc bộ.
    /// </summary>
    public Guid Id { get; private set; }

    /// <summary>
    /// Tên câu lạc bộ.
    /// </summary>
    public string Name { get; private set; }

    /// <summary>
    /// Mô tả câu lạc bộ.
    /// </summary>
    public string Description { get; private set; }

    /// <summary>
    /// Ngày tạo câu lạc bộ.
    /// </summary>
    public DateTime CreatedAt { get; private set; }

    /// <summary>
    /// Danh sách thành viên của câu lạc bộ.
    /// </summary>
    public List<Member> Members { get; private set; }
        = new List<Member>();

    // Constructor private.
    private Club(
        Guid id,
        string name,
        string description,
        DateTime createdAt)
    {
        Id = id;
        Name = name;
        Description = description;
        CreatedAt = createdAt;
    }

    /// <summary>
    /// Tạo câu lạc bộ mới.
    /// </summary>
    public static Club Create(string name, string description)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            throw new ArgumentException("Club name cannot be empty.");
        }

        if (string.IsNullOrWhiteSpace(description))
        {
            throw new ArgumentException("Description cannot be empty.");
        }

        Club club = new Club(
            Guid.NewGuid(),
            name.Trim(),
            description.Trim(),
            DateTime.Now);

        return club;
    }

    /// <summary>
    /// Thêm thành viên vào câu lạc bộ.
    /// </summary>
    public void AddMember(Member member)
    {
        if (member == null)
        {
            throw new ArgumentNullException(nameof(member));
        }

        foreach (Member item in Members)
        {
            if (item.Id == member.Id)
            {
                throw new InvalidOperationException(
                    "This member already exists in the club.");
            }
        }

        Members.Add(member);
    }

    /// <summary>
    /// Đếm số thành viên trong câu lạc bộ.
    /// </summary>
    public int MemberCount()
    {
        return Members.Count;
    }
}