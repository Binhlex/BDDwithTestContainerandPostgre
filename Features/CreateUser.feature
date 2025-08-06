Feature: Create user

  Scenario: Create a user and verify in database
    Given a user named "Alice" is created
    Then the user "Alice" should exist in the database