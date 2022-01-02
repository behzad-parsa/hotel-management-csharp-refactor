

# Hotel Manamgment System - Windows Application
### Overview
All the systems and organizations need to be handled. At this point, **the management systems** can be brought up to solve the problem. 

**The Hotel Project** is based on This purpose was designed and developed to arrange the related data, store and retrieve the data, then filter it, and, in the final stage, demonstrate the clear and correct information to the end users (or organizations).
### Table of Contents
- [Built-With](#built-with)
- [Description](#Description)
- [Architecture](#Architecture)
- [Features](#Features)
- [TODO](#TODO)

## Built With
- Back-end
  - C# Programming Language
- Front-End
  - Windows Form
  - Bunifu UI Framework
- Database
  - SQL SERVER
  - ASO .NET 


## Description
The first version of the hotel system was written in my college days in 2018. Recently,I decided to refactor my code in a different style and architecture, with efficient and clean code in a new repository with separate commits. The older version is available on my repo [here](https://github.com/behzad-parsa/hotel-management-csharp).

The idea is simple: we have 2 main **Actors** (customers and users) in the Database, who impact the program, and our main challenge is to manage **the flow of data** based on these actors.  

 - **Users** : They are the end users who are **Employees** either and register the data

 - **Customers** : They're going to be our direct clients,and they can have attendance, which is knowns as **Guests** in the Database

The program is supposed to be used within the company. For example, the reception section Employees, who are the end users, have access to register the customer's information or the manager can add or edit the employee's information. 

Technically, based on the role that was defined and the authority that was granted, end users may engage in activity.

## Architecture
The structure of this refactored version is built on a three-layer architecture, with each layer being responsible for its own set of tasks.

## Features
1. Login System
   - The Login System can identify the users and their roles on the system. Also, if the password is forgotten, they can retrieve it with the confirmation code that will be sent to their email.


     ![oie_png](https://user-images.githubusercontent.com/91433474/147874524-2a77b8c1-0b2c-46f5-a685-5f8cacf7c1e4.png) 
     ![oie_2122410YuMrauyP](https://user-images.githubusercontent.com/91433474/147874575-caae39c1-d263-4aca-af96-657e81e92998.png)



2. Password Hashing
   - The Password is encoded on the Database using ``` System.Security.Cryptography ``` library to improve the security .

3. Authority
   - Users have access on their section based the roles admin defined

3. Themes And Modern UI
   - Users have a beautiful environment and their options to customize the skin include: changing the theme, choosing a city (to get its weather based on api),..
## Database
## TODO List
- [ ] Mdofiy The Logic Based On The Three-Layer Architecture
- [ ] Improvments on The Ui Side
- [ ] Final Review 
## Usage
## Version History
## Licence
