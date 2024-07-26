Feature: LoginFormWithValidBadCredentials

@uc3
  Scenario: User logs in with valid credentials
    Given I am on the login page
    When I enter the username "<userName>"
    And I enter the password "<userPassword>"
    And I click the login button
    Then I should be on the shopping page

    Examples:
      | userName        | userPassword  |
      | locked_out_user | secret_sauce  | #Will not allow to login. Produces an error.
      | problem_user    | secret_sauce  |
      | error_user      | secret_sauce  |