Feature: LoginFormWithEmptyPassword

@uc2
  Scenario: User tries to login with a cleared password field and sees an error message
    Given I am on the login page
    When I enter the username "userName"
    And I enter the password "userPassword"
    And I clear the password field
    And I click the login button
    Then I should see an error message containing "Epic sadface: Password is required"