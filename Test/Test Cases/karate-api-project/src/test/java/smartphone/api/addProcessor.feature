Feature: Test /AddProcessors endpoint

Background:
    * configure read('karate-config.js')

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

    Given url baseUrl + endpoints.addProcessors
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

    Given url baseUrl + endpoints.addProcessors
    And request mypayload1
    When method POST
    Then status 201