# Application Readme

This is the readme file for an application written in .NET Core, which connects to a frontend written in Angular using REST API calls.

## Instructions

### API:
1. **Run the file with the extension .sln.**
2. **Switch the default server startup from HTTPS to IIS EXPRESS.**
3. **Start the application.** The database should be created automatically. If not, you can create it using the "update-database" command in the NuGet Packages terminal.
4. The application should open a web page with the following URL: [https://localhost:44347/swagger/index.html](https://localhost:44347/swagger/index.html).

### Frontend:
Requirements for the project:
- Angular CLI: 14.2.6
- Node: 16.20.0
- Package Manager: npm 9.6.3
- OS: win32 x64

To get started:
1. Make sure you have Node.js installed.
2. Open the command prompt and navigate to the "client" directory.
3. Run the command `npm install` or `npm install --force` if there are installation errors.
4. If everything goes well, run `ng serve` in the terminal. Make sure the API server is running and working correctly.
5. Open your browser and enter [http://localhost:4200/](http://localhost:4200/). You should see the Angular application running.

## Application Assumptions:
- Users can log in and register. During registration, sensitive information about cars is provided for security purposes to prevent theft.
- Users can only view cars that are available, i.e., not purchased or reserved by other users.
- Users can only register a car. To purchase a car, they need to visit the service center, where an admin can rent the car to them.
- Admin has additional privileges:
  - Admin can add new cars, and each car can have only one photo. Photos are stored in the Cloudinary service.
  - Admin can download information about a specific car and the user who rented it by using the car's VIN (Vehicle Identification Number), which serves as the primary key in the Cars table.
  - Admin can view sensitive user data and see all the cars a user has rented.
  - Admin can check the rental cost of a specific car using its VIN.
  - Admin can verify the user who last rented a car in case the car was damaged and the incident was not noticed immediately.
  - Admin can rent a car to a user. To rent a car, the user must first reserve it.
  - Additionally, the admin handles payments for cars, can delete a user from the car, and can change the user to another user who previously rented the car.
