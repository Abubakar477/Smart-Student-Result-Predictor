# 🎓 Smart Student Result Predictor

![v1.0.0](https://img.shields.io/badge/version-1.0.0-blue.svg)
![.NET 8](https://img.shields.io/badge/.NET-8.0-purple.svg)
![License](https://img.shields.io/badge/license-MIT-green.svg)

An intelligent, ML-powered Windows Forms application designed to predict student academic outcomes using modern binary classification techniques. 

## 🌟 Key Features

*   **🧠 Machine Learning Integration**: Leverages `ML.NET` with `SdcaLogisticRegression` to predict Pass/Fail outcomes based on academic performance.
*   **💻 Modern UI/UX**: Built with a sleek, dark-themed Windows Forms interface featuring smooth button animations and responsive layouts.
*   **🏗️ Solid Architecture**: Implements core Object-Oriented Programming (OOP) principles:
    *   **Inheritance**: `Student` inherits from a base `Person` class.
    *   **Encapsulation**: Secure property management.
    *   **Polymorphism**: Method overriding for customized student details.
*   **📊 Data Management**: View all student records in a formatted DataGrid view.
*   **🐳 Containerization**: Ready for deployment with a pre-configured `Dockerfile`.

## 🚀 Getting Started

### Prerequisites

*   [.NET 8.0 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
*   Visual Studio 2022 or VS Code

### Installation & Run

1.  **Clone the repository**:
    ```bash
    git clone https://github.com/Abubakar477/Smart-Student-Result-Predictor.git
    ```
2.  **Navigate to the project directory**:
    ```bash
    cd "Smart-Student-Result-Predictor"
    ```
3.  **Run the application**:
    ```bash
    dotnet run
    ```

## 🧠 How the ML Model Works

The application uses an internal `MLEngine` that:
1.  **Generates Synthetic Data**: Creates a baseline training set for demonstration.
2.  **Trains a Pipeline**: Concatenates features and applies a Binary Classification trainer.
3.  **Real-time Prediction**: Evaluates input marks instantly to provide a status prediction with a confidence percentage.

## 📁 Project Structure

*   `Form1.cs`: Primary UI for data entry and ML prediction.
*   `Form2.cs`: Secondary UI for displaying the full student list.
*   `MLEngine.cs`: Core logic for model training and prediction.
*   `StudentData.cs`: Data models for ML.NET input/output.
*   `Person.cs` / `Student.cs`: Domain models implementing OOP logic.

## 🛠️ Built With

*   [C#](https://docs.microsoft.com/en-us/dotnet/csharp/) - The programming language used.
*   [ML.NET](https://dotnet.microsoft.com/apps/machinelearning-ai/ml-dotnet) - Machine Learning framework for .NET.
*   [Windows Forms](https://docs.microsoft.com/en-us/dotnet/desktop/winforms/) - Desktop UI framework.

---

*Developed by Abubakar*
