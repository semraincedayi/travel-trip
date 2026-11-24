# TravelTrip

A dynamic travel blog built with **ASP.NET MVC 5**, **Entity Framework 6 (Code First)** and **Microsoft SQL Server**. Visitors can browse travel posts and comments, while the site owner manages blog content through an admin panel.

## Features

### Public site

- Home page with travel content and featured blog posts
- Blog listing and blog detail pages
- Comments on blog posts
- About and contact pages

### Admin panel

- Admin login and logout
- Session timeout after 10 minutes of inactivity
- Create, edit, delete and view blog posts
- View, edit and delete comments
- Edit the About page content

## Tech Stack

- C# and ASP.NET MVC 5
- .NET Framework 4.7.2
- Entity Framework 6.5.1 (Code First)
- Microsoft SQL Server
- Bootstrap, HTML, CSS and JavaScript

## Getting Started

### Requirements

Install the following before opening the project:

- **Visual Studio 2019 or 2022**, with the **ASP.NET and web development** workload
- **.NET Framework 4.7.2 Developer Pack / Targeting Pack**
- **SQL Server Express** (or another SQL Server instance)
- **SQL Server Management Studio (SSMS)** is recommended for managing the database

### 1. Download the project

Clone the repository:

```bash
git clone https://github.com/semraincedayi/travel-trip.git
```

Alternatively, download the repository as a ZIP file and extract it.

### 2. Open the solution in Visual Studio

Open the solution file at the repository root:

```text
TravelTrip.sln
```

If Visual Studio asks to restore NuGet packages, allow it to do so. You can also right-click the solution and select **Restore NuGet Packages**.

### 3. Configure the database connection

In Solution Explorer, open:

```text
TravelTrip/Web.config
```

Find the `Context` connection string:

```xml
<connectionStrings>
  <add name="Context"
       connectionString="Data Source=.\SQLEXPRESS;Initial Catalog=TravelDb;Integrated Security=True;TrustServerCertificate=True;MultipleActiveResultSets=True;"
       providerName="System.Data.SqlClient" />
</connectionStrings>
```

Change the `Data Source` value if your SQL Server instance has a different name.

Examples:

- SQL Server Express: `.\SQLEXPRESS`
- LocalDB: `(localdb)\MSSQLLocalDB`
- Default local SQL Server instance: `.`

You can also change `Initial Catalog=TravelDb` if you want to use a different database name. Keep the connection string name as `Context`; the application's `Context` DbContext uses this name.

### 4. Create / update the database

The project contains a `Migrations` folder and an Entity Framework migrations configuration with automatic migrations enabled.

In Visual Studio, open:

**Tools > NuGet Package Manager > Package Manager Console**

Make sure **Default project** is set to `TravelTrip`, then run:

```powershell
Update-Database
```

This applies the Entity Framework migrations and creates or updates the `TravelDb` database using the connection string configured above.

### 5. Run the application

In Visual Studio:

1. Select the `TravelTrip` project as the startup project, if it is not already selected.
2. Press **F5** (or click **IIS Express**) to build and run the application.
3. The public website should open in your browser.

## Admin panel

Open the login page at:

```text
/Login
```

**Important:** The project code checks the `Admins` table for a matching username and password, but the supplied project does not seed or define a default admin account. Therefore, there are no built-in login credentials.

After creating the database, add a local development account to the `Admins` table. For example, run this in SQL Server Management Studio against the `TravelDb` database:

```sql
INSERT INTO dbo.Admins (Username, Password)
VALUES ('admin', 'Admin123!');
```

Then sign in with these example credentials:

- **Username:** `admin`
- **Password:** `Admin123!`

This example account is for local development only. The current application stores and compares passwords as plain text; do not use this approach or the example password in a public/production deployment. Implement password hashing and change the credentials before deployment.

## Troubleshooting

- **Cannot connect to SQL Server:** Check that SQL Server is installed and running, and that the `Data Source` in `Web.config` matches your installed instance.
- **Database update fails:** Check that the Package Manager Console's **Default project** is `TravelTrip`, restore NuGet packages, and verify the connection string.
- **Targeting pack error:** Install the .NET Framework 4.7.2 Developer Pack, then reload the solution.
- **Admin login does not work:** Confirm that a row exists in `dbo.Admins` and that the username and password match exactly.

## Credits

The front-end template is based on the free **Easy Trip** template by [W3Layouts](https://w3layouts.com).
