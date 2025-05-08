Feature: Login

  Scenario Outline: Login with different credentials
    Given the user is on the login page
    When the user enters username "<username>" and password "<password>"
    Then the user should be logged in successfully

    Examples:
      | firstName           | lastName   |
      | testing             | testing    |
