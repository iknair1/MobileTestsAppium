# Introduction 
Run Acceptance tests for mobile app - currently only supports Android app

Tests written in C# and uses appium

### Getting Started

#### 1.	Installation process for local Automated Run

1. In a terminal, upload the signed version of the android app under test. 
   Replace the variables `path_to_the_signed_apk` and also replace `your_custom_id` in the below command
    ` curl -u "username:accesskey" -X POST "https://api-cloud.browserstack.com/app-automate/upload" -F "file=@path_to_the_signed_apk" -F "data={\"custom_id\": \"your_custom_id\"}"`
    If successfull you will see something like this:
    `{"app_url":"bs://914b268e2316a036ff2c3615b5a34b357caaf481","custom_id":"your_custom_id","shareable_id":"***/your_custom_id"}`
2. Add the above `your_custom_id` in the `app` variable set in /Drivers/DriverFactory.cs
3. Run the test through VS code

