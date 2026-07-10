# ABCD Mall Website

A shopping mall web app built with ASP.NET Core MVC — because a real mall has more going on than just a list of shops, so this project tries to bring that whole experience online: browsing stores, checking out the food court, booking movie tickets, flipping through a gallery, and leaving feedback. There's also an admin side where all of this content gets managed.

## What's inside

- **Shops** — browse the stores in the mall along with their details
- **Food Court** — see what's available to eat
- **Movie Booking** — check showtimes and book tickets
- **Gallery** — photos of the mall, events, and spaces
- **Feedback** — customers can leave reviews
- **Admin Area** — a separate section (built as its own ASP.NET Core Area) for managing shops, movies, gallery content, and feedback

## About the design

The goal was to make it feel like an actual mall, not another Bootstrap starter template. So instead of the default blue-and-system-font look, it's built around warm marigold gold, coral, and teal tones on a cream background, paired with Fraunces for headings and Nunito Sans for body text — something that feels warm and welcoming, like a family mall, rather than a generic dashboard.

## Tech stack

- ASP.NET Core MVC (C#)
- Bootstrap 5, heavily customized with a hand-built theme layer on top
- Google Fonts (Fraunces + Nunito Sans)
- SQL Server for the database

## Project structure

ABCDMallWebsite/

├── Areas/

│   └── Admin/  → admin panel, with its own Controllers, Models, Views

├── Controllers/         → controllers for the public-facing site

├── Models/

├── Views/

├── wwwroot/

│   ├── css/             → style.css, including the custom theme

│   ├── images/

│   └── js/

└── Program.cs

## Running it locally

```bash
git clone https://github.com/amna-670/ABCDMallWebsite.git
cd ABCDMallWebsite
dotnet restore
dotnet build
dotnet run
```

Update the connection string in `appsettings.json` first so it points to your own database.

---
Built by Amna.
