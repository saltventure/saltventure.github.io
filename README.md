<div align=center>
<h1>
  Salt Venture
  </h1>
</div>
<div align=center>

![GitHub Actions](https://img.shields.io/badge/github%20actions-%232671E5.svg?style=for-the-badge&logo=githubactions&logoColor=white)
![MicrosoftSQLServer](https://img.shields.io/badge/Microsoft%20SQL%20Sever-CC2927?style=for-the-badge&logo=microsoft%20sql%20server&logoColor=white)
![Figma](https://img.shields.io/badge/figma-%23F24E1E.svg?style=for-the-badge&logo=figma&logoColor=white)
![.Net](https://img.shields.io/badge/.NET-5C2D91?style=for-the-badge&logo=.net&logoColor=white)
![Chart.js](https://img.shields.io/badge/chart.js-F5788D.svg?style=for-the-badge&logo=chart.js&logoColor=white)
![JWT](https://img.shields.io/badge/JWT-black?style=for-the-badge&logo=JSON%20web%20tokens)
![React](https://img.shields.io/badge/react-%2320232a.svg?style=for-the-badge&logo=react&logoColor=%2361DAFB)
![Azure](https://img.shields.io/badge/azure-%230072C6.svg?style=for-the-badge&logo=microsoftazure&logoColor=white)
![Rider](https://img.shields.io/badge/Rider-000000.svg?style=for-the-badge&logo=Rider&logoColor=white&color=black&labelColor=crimson)
![Visual Studio Code](https://img.shields.io/badge/Visual%20Studio%20Code-0078d7.svg?style=for-the-badge&logo=visual-studio-code&logoColor=white)
![C#](https://img.shields.io/badge/c%23-%23239120.svg?style=for-the-badge&logo=c-sharp&logoColor=white)
![CSS3](https://img.shields.io/badge/css3-%231572B6.svg?style=for-the-badge&logo=css3&logoColor=white)
![HTML5](https://img.shields.io/badge/html5-%23E34F26.svg?style=for-the-badge&logo=html5&logoColor=white)
![JavaScript](https://img.shields.io/badge/javascript-%23323330.svg?style=for-the-badge&logo=javascript&logoColor=%23F7DF1E)
![TypeScript](https://img.shields.io/badge/typescript-%23007ACC.svg?style=for-the-badge&logo=typescript&logoColor=white)
![Postman](https://img.shields.io/badge/Postman-FF6C37?style=for-the-badge&logo=postman&logoColor=white)
![Swagger](https://img.shields.io/badge/-Swagger-%23Clojure?style=for-the-badge&logo=swagger&logoColor=white)
![Git](https://img.shields.io/badge/git-%23F05033.svg?style=for-the-badge&logo=git&logoColor=white)
![GitHub](https://img.shields.io/badge/github-%23121011.svg?style=for-the-badge&logo=github&logoColor=white)
  
</div>

<div align=center>
  <p>
    This Project was made in two weeks as a graduation project at <a href="http://salt.dev">School of Applied Technology</a> <br />
  
  </p>

</div>

## Table of Contents
- [Table of Contents](#table-of-contents)
- [About the Project](#about-the-project)
- [Overview](#overview)
- [Tech Stack](#tech-stack)
- [Getting Started](#getting-started)
  * [0. Requirements:](#0-requirements)
    + [.Net](#net)
    + [NPM](#npm)
    + [Docker ( Optional )](#docker--optional-)
  * [1. Clone the github project](#1-clone-the-github-project)
  * [2. Setting up Back End](#2-setting-up-back-end)
    + [2.1. Setting Up Docker](#21-setting-up-docker)
    + [2.2. Setting up the connection string](#22-setting-up-the-connection-string)
      * [2.2.1 Setting Up Entity Framework](#221-setting-up-entity-framework)
    + [2.3. Set up Token Key](#23-set-up-token-key)
    + [2.4. Trying it out.](#24-trying-it-out)
  * [3. Setting Up Front End](#3-setting-up-front-end)
- [Project Files Description](#project-files-description)
- [Contributors](#contributors)

## About the Project
<p>
Salt venture is a free gambling website where there is no real money involved, instead you compete with your friends to see who can accumulate the most points, or “salties” as we call it. This is also great for gambling companies to try out their games. Where they can track earnings, popularity, betting amounts, games return to player ratings, and overall feedback.
</p>


## Overview
<p>
  In this project, we had two weeks to create a full stack application using everything we learned during the 3 months long bootcamp at <a href="http://salt.dev">School of Applied Technology</a>.
  <br />
  We chose to work on this since we all like games, especially gambling games, but we don’t like to bet money. We also realized that these types of games are a bit more achievable in a two week time frame. While planning the project we also realized that there is a lot of useful data that can be collected from the games and the users, which was exciting to us.
</p>

## Tech Stack

- Back End
  - C#
  - ASP.NET Web API
  - Entity Framework
  - xUnit ( 150 tests so far! )
  - SQL Server
  - JWT (Authentication)
  - Azure ( Web App and SQL Server )
  
- Front End
  - React
  - Typescript
  - HTML
  - CSS
  - Chart.js
  - Github Pages

- Extra
  - Figma
  - Mobile First Approach
  - Mob Programming
  - Agile Methodology
## Getting Started
  ### 0. Requirements
  You'll need to have installed:
  #### .Net
  ```bash
  .NET 6.0 or higher
  ```
  To check your .NET version you can run:
  ```bash
  dotnet --list-sdks
  ```
  <br />
  
  #### NPM
   ```bash
  .npm 8.5.0 or higher
  ```
  To check your npm version, you can run:
  ```bash
  npm --version
  ```
  <br />
  
  #### Docker (Optional)
  ### 1. Clone the github project
  To Get Started, clone the github project to your own machine
  ```bash
  git clone https://github.com/saltventure/saltventure.github.io.git
  ```
  Inside the SaltVenture.API and SaltVenture.Tests folder, run:
  ```bash
  dotnet restore
  ```
  On the client folder, run:
  ```bash
  npm install
  ```
  ### 2. Setting up Back End
  You'll need to have a SQL Server runninng somewhere ( Recommended Docker )
  #### 2.1. Setting Up Docker
  If you don't have a SQL Server running anywhere, you can use docker
  First, install docker on your computer [Docker Download Link](https://docs.docker.com/get-docker/)
  After you have docker ready, run this command inside this repository's folder to set up docker.
  ```bash
  docker-compose up -d
  ```
  If you want to shut the SQL Server down, you can run:
  ```bash
  docker stop sql-server-db
  ```
  Note that the database is held in the container so when you shut it down the data is gone.
  #### 2.2. Setting up the connection string
  You need to get the SQL Server connection string to connect to the database, if you're using docker, you connection string might look like this:
  ```bash
  Server=localhost,1433;Database=SaltVenture;User Id=sa;password=Password_2_Change_4_Real_Cases_&
  ```
  Replace the connection string in the SaltVenture.API/appsettings.json with yours.
  
  We are using dotnet use-secrets in this project, if you also want to use user-secrets, follow this next steps:
  Replace your connection string with somethinng like this:
  ```bash
  Server=localhost,1433;Database=SaltVenture;User Id=<username>;password=<password>
  ```
  Set up your credentials
  ```bash
  dotnet user-secrets set "DB_USERNAME" "<YOUR_DB_USERAME>"
  dotnet user-secrets set "DB_PASSWORD" "<YOUR_DB_PASSWORD>"
  ```
  That's all!
  If you don't wannt to use user-secrets, remove line 14 & 15 from Program.cs.
  #### 2.2.1 Setting Up Entity Framework
  Now that you have a Database Server setted up, you need to add the tables to the Database.
  First make sure that you have *.NET Entity Framework tools* installed.
  ```bash
  dotnet tool install --global dotnet-ef
  ```
  Verify that it has been installed correctly by running
  ``bash
  dotnet ef
  ```
  You should get something that looks like this:
  ```bash
  _/\__
               ---==/    \\
         ___  ___   |.    \|\
        | __|| __|  |  )   \\\
        | _| | _|   \_/ |  //|\\
        |___||_|       /   \\\/\\

Entity Framework Core .NET Command-line Tools 2.1.3-rtm-32065

<Usage documentation follows, not shown.>

  ```
  Now that you have installed this tool, you need to create a migration by running:
  *Note: You´ll have to run this next two commands everytime you change a model to update the database.
  ```bash
  dotnet ef migrations add InitialMigration
  ```
 Now that you have a migration file, update the database.
   ```bash
    dotnet ef database update
   ```
  #### 2.3. Set up Token Key
  To use authentication, you have to set a secret token key for JWT. To do that, run:
  ```bash
  dotnet user-secrets set "TOKEN_KEY" "<YOUR_TOKEN_KEY>"
  ```
  This key doesn't have to be a especific string, it should be a random one.
  If you're not using user-secrets, in the Program.cs, replace 
  ```csharp
  var tokenKey = builder.Configuration["TOKEN_KEY"];
  ```
  with 
  ```csharp
  var tokenKey = "<YOUR_TOKEN_KEY>";
  ```
  #### 2.4. Trying it out.
  To make sure that it's working, run:
  ```bash
  dotnet run
  ```
  This will run your application, open the server on the indciated port, eg: 7034 and go to
  https://localhost:7034/swagger/index.html
  Try loggin in with the default values.
  If you get a 404 not found value with a message of "Email or password was wrong!", it means that it is working.
### 3. Setting Up Front End
On the client folder, make sure that you have installed all the modules needed:
 ```bash
  npm install
  ```
After that, Replace all the "https://saltventure.azurewebsites.net/" with your back end server eg:"https://localhost:7034/"
<br />
Lastly to start the front end server, run:
 ```bash
  npm start
  ```
 After that, you should have a front end running on this port:
  ```bash
  localhost:3000
  ```
## Project Files Description

## Contributors:
<table>
  <tr>
    <td align="center"><a href="https://github.com/salomaogabriel/"><img src="https://github.com/salomaogabriel.png" width="100px;" alt=""/><br /><sub><b>Gabriel Salomão</b></sub></a><br /><a href="https://github.com/saltventure/saltventure.github.io/commits?author=salomaogabriel" title="Code">💻</a></td>
   <td align="center"><a href="https://github.com/Qaisarm/"><img src="https://github.com/Qaisarm.png" width="100px;" alt=""/><br /><sub><b>Qaisar Mukhtar</b></sub></a><br /><a href="https://github.com/saltventure/saltventure.github.io/commits?author=Qaisarm" title="Code">💻</a></td>
    <td align="center"><a href="https://github.com/NicholasIzosimov/"><img src="https://github.com/NicholasIzosimov.png" width="100px;" alt=""/><br /><sub><b>Nicholas Izosimov</b></sub></a><br /><a href="https://github.com/saltventure/saltventure.github.io/commits?author=NicholasIzosimov" title="Code">💻</a></td>
  </tr>
</table>
