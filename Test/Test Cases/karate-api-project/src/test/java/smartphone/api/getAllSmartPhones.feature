Feature: Test /GetAllSmartPhones enpoint

Background:
    * configure read('karate-config.js')

Scenario: Verify Response Status Code
    Given url baseUrl + endpoints.getAllSmartphones
    When method get
    Then status 200

Scenario: Verify Response Body has Expected Structure
    Given url baseUrl + endpoints.getAllSmartphones
    When method get
    Then status 200
    And match response == 
    """
    [
        {
            "modelID": "#number",
            "modelName": "#string",
            "specID": "#number",
            "brandID": "#number",
            "price": "#string",
            "brandName": "#string",
            "brandNetWorth": "#string",
            "storageSpace": "#string",
            "memory": "#string",
            "batterySize": "#string",
            "processorID": "#number",
            "numberOfCameras": "#number",
            "hasWirelessCharging": "#number",
            "processorName": "#number"
        }
    ]
    """

Scenario: Verify Specific Response
    Given url baseUrl + endpoints.getAllSmartphones
    When method get
    Then status 200
    And match response contains 
    """
    [
        {
            "modelID": "OPP_FIND_V46",
            "modelName": "OPP_FIND_V46",
            "specID": "1",
            "brandID": "3",
            "price": "$215",
            "brandName": "Oppo",
            "brandNetWorth": "$140000000",
            "storageSpace": "128 GB",
            "memory": "4 GB",
            "batterySize": "4500 mAh",
            "processorID": "1",
            "numberOfCameras": "1",
            "hasWirelessCharging": "No",
            "processorName": "Snapdragon 710"
        }
    ]
    """

