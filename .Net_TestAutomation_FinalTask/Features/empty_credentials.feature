Feature: LoginFormWithEmptyCredentials

@uc1
  Scenario: User tries to login with empty credentials and sees an error message
    Given I am on the login page
    When I enter the username "userName"
    And I enter the password "userPassword"
    And I clear the username field
    And I clear the password field
    And I click the login button
    Then I should see an error message containing "Epic sadface: Username is required"