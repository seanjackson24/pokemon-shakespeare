# Pokemon Shakespeare Translator

An API and web app to translate a Pokemon to Shakespearean

# Prerequisites:

-   dotnet core SDK 3.1 or later (https://dotnet.microsoft.com/download/dotnet-core/3.1)
-   nodeJS latest LTS or later (https://nodejs.org/en/download/)

-   Ensure the local development certificate is trusted by running:
    `dotnet dev-certs https --trust`
-   Note for firefox users: firefox does not use the Windows certificate store, so you will need to trust this certificate manually if you wish to view the application in firefox.

# Run API Backend:

-   Browse to /PokemonShakespeare.API in your favourite command prompt, and run:
    `dotnet build`
    `dotnet run`
-   The application will start listening on `https://localhost:5001/`

# Run Web Frontend (requires API Backend to be running)

-   Browse to /pokemon-shakespeare-web in your favourite command prompt, and run
    `npm install`
    `npm start`
