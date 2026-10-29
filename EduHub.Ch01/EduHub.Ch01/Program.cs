
using EduHub.Ch01.Domain;
using System.Text;

// Hien thi tieng Viet tren man hinh Console
Console.OutputEncoding = Encoding.UTF8;

// 1. Tao cau lac bo
Console.WriteLine("========================================");
Console.WriteLine("     EDUHUB - AI WORKSHOP MANAGEMENT");
Console.WriteLine("========================================");

Club club = Club.Create(
    "Tech Club",
    "Student club organizing AI workshops.");

Console.WriteLine("\n1. CLUB INFORMATION");
Console.WriteLine("Club name: " + club.Name);
Console.WriteLine("Description: " + club.Description);


// 2. Tao 3 thanh vien
Member member1 = Member.Create(
    "Nguyen Van An",
    "an@gmail.com",
    "SV001");

Member member2 = Member.Create(
    "Tran Thi Binh",
    "binh@gamil.com",
    "SV002");

Member member3 = Member.Create(
    "Le Van Cuong",
    "cuong@gmail.com",
    "SV003");

// Them thanh vien vao cau lac bo
club.AddMember(member1);
club.AddMember(member2);
club.AddMember(member3);

Console.WriteLine("\n2. CLUB MEMBERS");

foreach (Member member in club.Members)
{
    Console.WriteLine(
        "- " + member.Name +
        " | Student code: " + member.StudentCode);
}

Console.WriteLine("Total members: " + club.MemberCount());


// 3. Tao su kien Workshop AI
Event aiWorkshop = Event.Create(
    club.Id,
    "Workshop AI",
    DateTime.Now.AddDays(7),
    50,
    true);

Console.WriteLine("\n3. EVENT INFORMATION");
Console.WriteLine("Event: " + aiWorkshop.Title);
Console.WriteLine(
    "Date: " + aiWorkshop.Date.ToString("dd/MM/yyyy HH:mm"));
Console.WriteLine("Capacity: " + aiWorkshop.Capacity);

if (aiWorkshop.IsOnline)
{
    Console.WriteLine("Format: Online");
}
else
{
    Console.WriteLine("Format: Offline");
}


// 4. Tao dang ky cho 2 thanh vien
List<Registration> registrations = new List<Registration>();

if (aiWorkshop.HasCapacity(registrations.Count))
{
    Registration registration1 =
        Registration.Create(member1.Id, aiWorkshop.Id);

    registrations.Add(registration1);
}

if (aiWorkshop.HasCapacity(registrations.Count))
{
    Registration registration2 =
        Registration.Create(member2.Id, aiWorkshop.Id);

    registrations.Add(registration2);
}

Console.WriteLine("\n4. EVENT REGISTRATIONS");

foreach (Registration registration in registrations)
{
    Console.WriteLine(
        "Member ID: " + registration.MemberId +
        " | Status: " + registration.Status);
}


// 5. Xac nhan cac dang ky
foreach (Registration registration in registrations)
{
    registration.Confirm();
}

Console.WriteLine("\n5. CONFIRMED REGISTRATIONS");

foreach (Registration registration in registrations)
{
    Console.WriteLine(
        "Member ID: " + registration.MemberId +
        " | Status: " + registration.Status);
}


// 6. Check-in cho thanh vien da dang ky
List<CheckIn> checkIns = new List<CheckIn>();

if (registrations.Count > 0)
{
    CheckIn checkIn = CheckIn.Create(
        registrations[0].Id,
        CheckIn.QrMethod);

    checkIns.Add(checkIn);

    Console.WriteLine("\n6. CHECK-IN");
    Console.WriteLine("Member: " + member1.Name);
    Console.WriteLine(checkIn.Summary());
}


// 7. Dem so dang ky da xac nhan
int confirmedCount = 0;

foreach (Registration registration in registrations)
{
    if (registration.Status == Registration.ConfirmedStatus)
    {
        confirmedCount++;
    }
}


// 8. In bao cao cuoi chuong trinh
Console.WriteLine("\n========================================");
Console.WriteLine("               FINAL REPORT");
Console.WriteLine("========================================");

Console.WriteLine("Club: " + club.Name);
Console.WriteLine("Total members: " + club.MemberCount());
Console.WriteLine("Event: " + aiWorkshop.Title);
Console.WriteLine("Total registrations: " + registrations.Count);
Console.WriteLine("Confirmed registrations: " + confirmedCount);
Console.WriteLine("Total check-ins: " + checkIns.Count);

Console.WriteLine("\nRegistered members:");

foreach (Registration registration in registrations)
{
    if (registration.MemberId == member1.Id)
    {
        Console.WriteLine("- " + member1.Name);
    }
    else if (registration.MemberId == member2.Id)
    {
        Console.WriteLine("- " + member2.Name);
    }
    else if (registration.MemberId == member3.Id)
    {
        Console.WriteLine("- " + member3.Name);
    }
}

Console.WriteLine("\nChecked-in members:");

if (checkIns.Count > 0)
{
    Console.WriteLine("- " + member1.Name);
}

Console.WriteLine("========================================");
Console.WriteLine("Program completed successfully.");
