## Academic-Project-Repository Project Structure

Your project architecture consists of three main components:

### 1. **Shared Project**
   - **Type**: Console Application
   - **Purpose**: Contains shared logic, models, and services that are used by both the client and server projects. This promotes code reusability and consistency across the application.
   - **Benefits**:
     - Avoids code duplication.
     - Ensures consistency in logic and data models.
     - Simplifies maintenance and updates.

### 2. **Server Project**
   - **Type**: Web API
   - **Purpose**: Handles backend operations, including data processing, business logic, and communication with the database. It references the shared project to utilize common models and services.
   - **Benefits**:
     - Clear separation of backend logic.
     - Utilizes shared resources to maintain consistency.

### 3. **Client Project**
   - **Type**: Blazor Standalone App
   - **Purpose**: Manages the frontend user interface and client-side logic. It references the shared project to use common models and services, ensuring the frontend and backend are in sync.
   - **Benefits**:
     - Clear separation of frontend logic.
     - Utilizes shared resources to maintain consistency.

---

### **Overall Benefits**
- **Code Reusability**: Shared logic and models prevent code duplication.
- **Consistency**: Ensures both client and server use the same definitions and logic.
- **Maintainability**: Easier to update and maintain shared code.
- **Separation of Concerns**: Modular structure makes the codebase easier to understand.
- **Testing**: Shared logic can be tested independently.
- **Scalability**: Easier to scale and extend the application.
- **Development Efficiency**: Allows parallel development on different parts of the application.

---

### **Steps to Run Your Project**

1. **Ensure Prerequisites**:
   - Make sure you have the .NET SDK installed. You can download it from the official [.NET website](https://dotnet.microsoft.com/).

2. **Open the Solution**:
   - Open your solution in JetBrains Rider.

3. **Restore NuGet Packages**:
   - In Rider, go to **Tools > NuGet > Restore NuGet Packages** to ensure all dependencies are installed.

4. **Build the Solution**:
   - Build the entire solution by selecting **Build > Build Solution** or pressing `Cmd+Shift+B`.

5. **Run the Server Project**:
   - Set the Server project as the startup project.
   - Run the Server project by clicking the **Run** button or pressing `Ctrl+R`.

6. **Run the Client Project**:
   - Set the Client project as the startup project.
   - Run the Client project by clicking the **Run** button or pressing `Ctrl+R`.

7. **Verify the Shared Project**:
   - Ensure that both the Client and Server projects reference the Shared project correctly.

8. **Access the Application**:
   - Open a web browser and navigate to the URL where your Server project is hosted (e.g., `http://localhost:5000`).

By following these steps, you should be able to run your project successfully.
