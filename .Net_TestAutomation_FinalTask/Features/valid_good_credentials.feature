Feature: LoginFormWithValidGoodCredentials

@uc4
  Scenario: User logs in with valid credentials
    Given I am on the login page
    When I enter the username "<userName>"
    And I enter the password "<userPassword>"
    And I click the login button
    Then I should be on the shopping page

    Examples:
      | userName        | userPassword  |
      | standard_user   | secret_sauce  |
      | visual_user     | secret_sauce  |