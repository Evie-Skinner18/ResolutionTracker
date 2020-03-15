# Resolution Tracker

An ASP.Net Core MVC application to help me track my new year's resolutions

## Tools and Technologies Used:
- .Net Core 3.1
- .Net Core CLI
- Entity Framework Core
- PostgreSQL
- HTML
- CSS
- JavaScript
- Bootstrap
- [Inconsolata font](https://fonts.google.com/specimen/Inconsolata) by Ralph Levien
- Dependency injection
- Service layer
- Data access layer

More features: enable text/email notifications or reminders. Make separate service in service layer for this. Use SASSy CSS. Use Vue on the front end and use JavaScript controller/service to display different HTML elements depending on the specific type of resolution. E.g if it's a MusicResolution, instruct Vue to show the Music Genre and Instrument input fields aswell so the user can update these only for a MusicResolution. Keep business logic to service layer so you won't have to test the controller! Only the services.
