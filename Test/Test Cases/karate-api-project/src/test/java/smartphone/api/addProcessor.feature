Feature: Test /AddProcessors endpoint

Background:
    * url 'https://localhost:5002'

Scenario: Add new Processor
    * def payload1 =
    """
    {"processorID":"${processorId}","processorName":"${processorName}"}
    """

    * replace payload1
    | token            | value    |
    | ${processorID}   | 1        |
    | ${processorName} | TestCPU  |

    * json mypayload1 = payload1

    Given path '/AddProcessors'
    And request mypayload1
    When method POST
    Then status 201


Scenario: Add Invalid Processor
    * def payload1 =
    """
    {"processorID":"${processorId}","processorName":"${processorName}"}
    """

    * replace payload1
    | token            | value                  |
    | ${processorID}   | 8                      |
    | ${processorName} | asdajfhhuqehqwbfasxka  |

    * json mypayload1 = payload1

    Given path '/AddProcessors'
    And request mypayload1
    When method POST
    Then status 201