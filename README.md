# Bookflow-Ecommerce

Bookflow-Ecommerce is a web application developed using ASP.NET Core MVC with .NET 8 and Razor Pages for the "Active Web Page Design" course. This project consists of a mini e-commerce platform for book sales, with the ability to add book categories and relate them to inventory. It also includes features such as discounts, payment processing with Stripe, and authentication using Facebook, Microsoft, and personal email accounts.

## Features

- **Book Catalog**: Browse and search for books from various categories.
- **Shopping Cart**: Add desired books to the cart and proceed to checkout.
- **Discounts**: Apply discounts and promotional offers to orders.
- **Payment Processing**: Securely process payments using Stripe integration.
- **Authentication**: Sign in with Facebook, Microsoft, or personal email accounts.
- **User Profiles**: Manage user profiles and order history.
- **Admin Panel**: Administrators can manage book categories, inventory, and user accounts.

## Technologies Used

- ASP.NET Core MVC
- .NET 8
- Razor Pages
- Entity Framework
- .NET UserProvider
- Stripe Payment Gateway
- Facebook, Microsoft, and Email Authentication

## Getting Started

To run the project locally, follow these steps:

1. Clone the repository: `git clone https://github.com/JosueG15/Bookflow-Ecommerce.git`
2. Navigate to the project directory: `cd Bookflow-Ecommerce`
3. Restore NuGet packages: `dotnet restore`
4. Configure the application settings (e.g., database connection strings, Stripe keys, authentication settings).
5. Apply database migrations: `dotnet ef database update`
6. Run the application: `dotnet run`

## Contributing

Contributions are welcome! If you find any issues or have suggestions for improvements, please open an issue or submit a pull request.

## License

This project is licensed under the [MIT License](LICENSE).
