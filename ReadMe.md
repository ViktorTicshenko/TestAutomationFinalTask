# SauceDemo Login Automation Testing

## Task Description

This project involves creating automated tests for the login functionality of the SauceDemo website. The tests will verify different scenarios related to the login form. The following use cases (UC) will be covered:

### UC-1: Test Login Form with Empty Credentials

1. Type any credentials into "Username" and "Password" fields.
2. Clear the inputs.
3. Hit the "Login" button.
4. Check for the error message: "Username is required".

### UC-2: Test Login Form with Credentials by Passing Username

1. Type any credentials in the "Username" field.
2. Enter password.
3. Clear the "Password" input.
4. Hit the "Login" button.
5. Check for the error message: "Password is required".

### UC-3: Test Login Form with Valid Credentials

1. Type credentials in the "Username" field which are under the Accepted usernames section.
2. Enter the password as "secret_sauce".
3. Click on the "Login" button and validate that the title “Swag Labs” appears on the dashboard.

## Requirements

- Parallel execution of tests.
- Logging for tests.
- Data Provider to parameterize tests.

## Tools and Technologies

- **Test Automation Tool**: Selenium WebDriver
- **Browsers**: 
  - Edge
  - Chrome
- **Locators**: XPath
- **Test Runner**: MS Test
- **Patterns (Optional)**: 
  - Abstract Factory
  - Adapter
  - Decorator
- **Test Automation Approach**: BDD (Behavior-Driven Development)
- **Assertions**: Fluent Assertion
- **Loggers (Optional)**: NLog

## Launch URL

https://www.saucedemo.com/

## Instructions

1. Set up the project environment with the necessary dependencies.
2. Implement the test cases for UC-1, UC-2, and UC-3.
3. Ensure parallel execution of the tests.
4. Implement logging for all tests.
5. Use a Data Provider to parameterize the test inputs.
6. (Optional) Apply design patterns such as Abstract Factory, Adapter, and Decorator where appropriate.
7. Use BDD for structuring the tests.
8. Utilize Fluent Assertions for test verifications.
9. (Optional) Integrate NLog for logging purposes.

## Running the Tests

1. Clone the repository.
2. Install the necessary dependencies.
3. Configure the browsers (Edge and Chrome) for Selenium WebDriver.
4. Execute the tests using MS Test.

## Notes

- Ensure that all three use cases (UC-1, UC-2, UC-3) are supported by parallel execution, logging, and parameterized tests.
- Follow best practices for test automation and code quality.

## Conclusion

This project aims to ensure robust and reliable login functionality for the SauceDemo website through comprehensive automated testing. By following the above instructions and utilizing the specified tools and technologies, the tests will effectively validate the login scenarios and help maintain a high standard of quality.