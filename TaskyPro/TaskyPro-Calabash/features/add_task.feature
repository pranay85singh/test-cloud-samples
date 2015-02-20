Feature: Add New Task
  A user should be able to add a new task to the list. They should also be able to change their
  mind and cancel adding the task.

  Scenario: Add a new Task
    Given I am on the Task Details screen
    When I add the "LearnObjectiveC" task

    Then I should be on the TaskyPro screen
    And I should see the "Learn Objective-C" task in the list

  Scenario: Change my mind and cancel adding a Task
    Given I am on the Task Details screen
    When I start to add the "LearnJava" task
    And I press the Cancel button

    Then I should be on the TaskyPro screen
    And I should not see the "Learn Java" task in the list

  Scenario: Check the 3 digit verification number
    Given I am on the Credit Card Screen
    And I have entered the credit number
    When I enter a valid 3 character code on the back of the card
    Then I should see a success message