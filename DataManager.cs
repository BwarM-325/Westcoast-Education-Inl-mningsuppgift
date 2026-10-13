using System.IO;
using System.Text.Json;

namespace WestCoastEdu;

public static class DataManagment
{
    private static readonly string folderCreate = "JSON";

    public static void SaveData(List<Students> students, List<Teachers> teachers, List<Courses> courses, List<Supervisors> supervisors, List<Admins> admins)
    {
        Directory.CreateDirectory(folderCreate);
        var save = new JsonSerializerOptions {WriteIndented = true};

        File.WriteAllText(Path.Combine(folderCreate, "students.json"), JsonSerializer.Serialize(students, save));
        File.WriteAllText(Path.Combine(folderCreate, "teachers.json"), JsonSerializer.Serialize(teachers, save));
        File.WriteAllText(Path.Combine(folderCreate, "courses.json"), JsonSerializer.Serialize(courses, save));
        File.WriteAllText(Path.Combine(folderCreate, "supervisors.json"), JsonSerializer.Serialize(supervisors, save));
        File.WriteAllText(Path.Combine(folderCreate, "admins.json"), JsonSerializer.Serialize(admins, save));        
    }

    public static void LoadData(List<Students> students, List<Teachers> teachers, List<Courses> courses, List<Supervisors> supervisors, List<Admins> admins)
    {
        string studentLocation = Path.Combine(folderCreate, "students.json");
        string teacherLocation = Path.Combine(folderCreate, "teachers.json");
        string courseLocation = Path.Combine(folderCreate, "courses.json");
        string supervisorLocation = Path.Combine(folderCreate, "supervisors.json");
        string adminLocation = Path.Combine(folderCreate, "admins.json");

        if (File.Exists(studentLocation)) {
            string json = File.ReadAllText(studentLocation);
            var loaded = JsonSerializer.Deserialize<List<Students>>(json);
            if (loaded != null) 
            {
                students.Clear();
                students.AddRange(loaded);
            }
        }
        if (File.Exists(teacherLocation)) {
            string json = File.ReadAllText(teacherLocation);
            var loaded = JsonSerializer.Deserialize<List<Teachers>>(json);
            if (loaded != null) 
            {
                teachers.Clear();
                teachers.AddRange(loaded);
            }
        }
        if (File.Exists(courseLocation)) {
            string json = File.ReadAllText(courseLocation);
            var loaded = JsonSerializer.Deserialize<List<Courses>>(json);
            if (loaded != null) 
            {
                courses.Clear();
                courses.AddRange(loaded);
            }
        }
        if (File.Exists(supervisorLocation)) {
            string json = File.ReadAllText(supervisorLocation);
            var loaded = JsonSerializer.Deserialize<List<Supervisors>>(json);
            if (loaded != null) 
            {
                supervisors.Clear();
                supervisors.AddRange(loaded);
            }
        }
        if (File.Exists(adminLocation)) {
            string json = File.ReadAllText(adminLocation);
            var loaded = JsonSerializer.Deserialize<List<Admins>>(json);
            if (loaded != null) 
            {
                admins.Clear();
                admins.AddRange(loaded);
            }
        }
    }
}