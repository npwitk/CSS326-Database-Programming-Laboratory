# Lab 6 - Database Programming using C# & MySQL
---

## 1. Outline

### Required Tools:
- **MAMP** (for MySQL server)
- **Visual Studio 2022** (on Windows OS or virtual machine)

### Application Structure:
- **Form 1:** User Signup Database
- **Form 2:** User page (All users)
- **Form 3:** User Update page (Edit)

### Key Files:
- `InfoDAO.cs` (Data Access Object)
- `Info.cs` (Data model)
- `Userpage.cs` (User display form)
- `Updatepage.cs` (Update form)

---

## 2. Create a Database

### SQL Command:
```sql
CREATE DATABASE IF NOT EXISTS test;
```

### Steps:
- Use phpMyAdmin interface
- Execute the SQL command in the query box
- Verify database creation in the left panel

---

## 3. Create a Table & Inserts

### Create Table:
```sql
USE test;
CREATE TABLE signup (
    ID int auto_increment PRIMARY KEY,
    First_Name Varchar(30), 
    Last_Name Varchar(30),
    Sex varchar(30), 
    BirthDate Date, 
    Email varchar (50),
    Occupation varchar(50)
);
```

### Insert Sample Data:
```sql
USE test;
INSERT INTO signup 
(First_Name, Last_Name, Sex, BirthDate, Email, Occupation)
VALUES 
('David', 'Crud', 'Male', '1992-02-24', 'david_crud@gmail.com', 'Engineer'),
('Marlon', 'Blake', 'Male', '1998-05-13', 'marlon_blake@gmail.com', 'Management Trainee');
```

---

## 4. User Interface

### Form Components:

#### Sign-up Form:
- **Title:** Information Collector
- **Fields:**
  - First name (TextBox)
  - Last name (TextBox)
  - Sex (ComboBox)
  - Birth Date (DateTimePicker)
  - Email (TextBox)
  - Occupation (TextBox)
- **Submit Button**

#### User Page:
- **DataGridView** to display all users
- **Update Button**
- **Delete Button**

---

## 5. Data Access Object & Connect to Database

### Info.cs (Data Model):
```csharp
public class info
{
    public int ID { set; get; }
    public string? fName { set; get; }
    public string? LName { set; get; }
    public string? Sex { set; get; }
    public string? Bdate { set; get; }
    public string? Email { set; get; }
    public string? Occup { set; get; }
    
    public static List<info> info_try = new List<info>();
}
```

### Creating and Passing Data:

#### In Sign-up Page Submit Button Event:
```csharp
infoDAO infoDAO = new infoDAO();
info a1 = new info() 
{
    ID = 1,
    fName = fname.Text,
    LName = lname.Text,
    Sex = sxCombo.Text,
    Bdate = birthDatePick.Text,
    Email = email.Text,
    Occup = occupation.Text,
};
infoDAO.info_try.Add(a1);
userpage newuserpage = new userpage(infoDAO.info_try);
newuserpage.ShowDialog();
```

#### In User Page Constructor:
```csharp
public userpage(object v)
{
    InitializeComponent();
    V = v;
}
public object V { get; set; }
```

#### In User Page Load Event:
```csharp
BindingSource infobindingSource = new BindingSource();

private void userpage_Load(object sender, EventArgs e)
{
    infobindingSource.DataSource = V;
    userdataGridView.DataSource = infobindingSource;
}
```

### Database Connection String:
```csharp
string connectionString = "datasource=localhost;port=3306;username=root;password=root;database=test;";
```

### InfoDAO.cs - Connection Setup:
```csharp
public List<info> getAll()
{
    List<info> returnall = new List<info>();
    MySqlConnection connect = new MySqlConnection(connectionString);
    connect.Open();
    // Query logic here
}
```

**Note:** Install NuGet package `MySql.Data` for MySQL connectivity

---

## 6. Query the Database

### Select All Records:
```csharp
MySqlCommand cmd = new MySqlCommand("SELECT * FROM signup", connect);

using (MySqlDataReader reader = cmd.ExecuteReader())
{
    while (reader.Read())
    {
        info ret = new info
        {
            ID = reader.GetInt32(0),
            fName = reader.GetString(1),
            LName = reader.GetString(2),
            Sex = reader.GetString(3),
            Bdate = reader.GetString(4),
            Email = reader.GetString(5),
            Occup = reader.GetString(6)
        };
        returnall.Add(ret);
    }
}
connect.Close();
return returnall;
```

### Creating User Page with Database Data:
```csharp
infoDAO infor = new infoDAO();
userpage newuserpage = new userpage(infor.getAll());
newuserpage.ShowDialog();
```

### Insert New Record:

#### In Signup Form Submit Event:
```csharp
string dateValue = birthDatePick.Value.ToString("yyyy-MM-dd");
info a1 = new info()
{
    ID = 1,
    fName = fname.Text,
    LName = lname.Text,
    Sex = sxCombo.Text,
    Bdate = dateValue,
    Email = email.Text,
    Occup = occupation.Text,
};
infoDAO infor = new infoDAO();
int result = infor.addOneRecord(a1);
MessageBox.Show(result + " new row(s) added.");
```

#### addOneRecord Function in InfoDAO.cs:
```csharp
MySqlConnection connect = new MySqlConnection(connectionString);
connect.Open();
MySqlCommand cmd = new MySqlCommand(
    "INSERT INTO `signup`(`First_Name`, `Last_Name`, `Sex`, `BirthDate`, `Email`, `Occupation`) VALUES (@fname,@lname,@sex,@birthdate,@email,@occupation)",
    connect);

cmd.Parameters.AddWithValue("@fname", a1.fName);
cmd.Parameters.AddWithValue("@lname", a1.LName);
cmd.Parameters.AddWithValue("@sex", a1.Sex);
cmd.Parameters.AddWithValue("@birthdate", a1.Bdate);
cmd.Parameters.AddWithValue("@email", a1.Email);
cmd.Parameters.AddWithValue("@occupation", a1.Occup);

int newRows = cmd.ExecuteNonQuery();
connect.Close();
return newRows;
```

---

## 7. Update & Delete Data from the Table

### Cell Click Event (Get Selected Row):
```csharp
private void userdataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
{
    DataGridView dataGridView = (DataGridView)sender;
    rowClicked = dataGridView.CurrentRow.Index;
    id_row = Int32.Parse(dataGridView.Rows[rowClicked].Cells[0].Value.ToString());
}
```

### Update Button Click Event:
```csharp
private void update_Click(object sender, EventArgs e)
{
    infoDAO infor = new infoDAO();
    this.Hide();
    updatepage newupdatepage = new updatepage(id_row);
    newupdatepage.ShowDialog();
}
```

### Update Page Submit Event:
```csharp
private void submit_Click(object sender, EventArgs e)
{
    string dateValue = birthDatePick.Value.ToString("yyyy-MM-dd");
    info a1 = new info()
    {
        ID = V,
        fName = fname.Text,
        LName = lname.Text,
        Sex = sxCombo.Text,
        Bdate = dateValue,
        Email = email.Text,
        Occup = occupation.Text,
    };
    infoDAO infor = new infoDAO();
    int result = infor.updateOneRecord(a1);
    this.Hide();
    userpage newuserpage = new userpage(infor.getAll());
    newuserpage.ShowDialog();
}
```

### Update Function in InfoDAO.cs:
```csharp
internal int updateOneRecord(info a1)
{
    MySqlConnection connect = new MySqlConnection(connectionString);
    connect.Open();
    MySqlCommand cmd = new MySqlCommand(
        "UPDATE signup SET First_Name=@fname, Last_Name=@lname, Sex=@sex, BirthDate=@birthdate, Email=@email, Occupation=@occupation WHERE ID=@ID",
        connect);
    
    cmd.Parameters.AddWithValue("@ID", a1.ID);
    cmd.Parameters.AddWithValue("@fname", a1.fName);
    cmd.Parameters.AddWithValue("@lname", a1.LName);
    cmd.Parameters.AddWithValue("@sex", a1.Sex);
    cmd.Parameters.AddWithValue("@birthdate", a1.Bdate);
    cmd.Parameters.AddWithValue("@email", a1.Email);
    cmd.Parameters.AddWithValue("@occupation", a1.Occup);
    
    int newRows = cmd.ExecuteNonQuery();
    connect.Close();
    return newRows;
}
```

### Delete Record:

#### Delete Button Click Event:
```csharp
private void delete_Click(object sender, EventArgs e)
{
    infoDAO infor = new infoDAO();
    int result = infor.deleteOneRecord(id_row);
    this.Hide();
    userpage newuserpage = new userpage(infor.getAll());
    newuserpage.ShowDialog();
}
```

#### Delete Function in InfoDAO.cs:
```csharp
internal int deleteOneRecord(int id_row)
{
    MySqlConnection connect = new MySqlConnection(connectionString);
    connect.Open();
    MySqlCommand cmd = new MySqlCommand(
        "DELETE FROM `signup` WHERE `signup`.`ID` = @ID",
        connect);
    
    cmd.Parameters.AddWithValue("@ID", id_row);
    int newRows = cmd.ExecuteNonQuery();
    connect.Close();
    return newRows;
}
```

---

## 8. Troubleshooting & Tips

### Connection Test Code:
```csharp
string connectionString = null;
MySqlConnection cnn;
string connectionString = "datasource=localhost;port=3306;username=root;password=root;database=test;";
cnn = new MySqlConnection(connectionString);

try
{
    cnn.Open();
    MessageBox.Show("Connection Open!");
    cnn.Close();
}
catch (Exception ex)
{
    MessageBox.Show("Can not open connection!");
}
```
