# Android Quickstart (Xamarin.UITest)
This quickstart shows you the easiest way to create a basic test for your Android application using Xamarin.UITest.

## Setting your API Key
Your API key for Xamarin Test Cloud is required if you wish to run on physical devices, or for test sessions longer than 15 minutes. You can find your API Key using the following instructions:
1. Log in to the [http://testcloud.xamarin.com](Xamarin Test Cloud portal).
2. Find your name in the upper right. Click it, and go to *Account Settings*.
3. On the lower left, find the organization you want to upload tests for, and click *Teams and Apps*. 
4. Click *Show API Key* for the team you want to upload tests to. API keys in Xamarin Test Cloud are shared per team.
5. Open `ApiKey.cs` in the sample project and replace the empty string with your API key. There are also [http://developer.xamarin.com/guides/testcloud/uitest/setting-the-api-key/](other options for setting your API key), which we encourage you to check out. 

## Running the sample locally
The sample is ready to build with a sample app, the Xamarin T-Shirt Store app. All you need to do is provide your API key.
To run the sample:
1. Start an Android emulator or plug in a physical device. The device should be in the list when you type `adb devices` at a terminal.
2. Open the solution in Xamarin Studio or Visual Studio.
3. Run unit tests from the IDE. You can also do this from a console window after building the solution by typing `nunit-console.exe pathToTestDllFolder` at a command prompt.

## Uploading this test to Xamarin Test Cloud
Detailed instructions are available in the [http://developer.xamarin.com/guides/testcloud/submitting/](Submitting Tests documentation).
1. Log in to [http://testcloud.xamarin.com](Xamarin Test Cloud) and click *New Test Run* in the upper right.
2. Select *New Android app* and choose your team.
3. Follow the instructions until you have a command line to execute.
4. Modify the paths and execute the command line. 

## Modifying this sample
1. Clone the repo or download the sample code.
2. In `ApiKey.cs`, change your API Key (see Finding Your API Key section below)
3. In `Test.cs`, change the `pathToBinary` variable to point to the location of your desired Android `.apk` bundle on disk. 
4. After you've linked up your app, you can remove `com.xamarin.XamStore.apk` from the solution if you wish.

## What next?
Now that you have a functioning environment set up for Xamarin.UITest, and have successfully uploaded a test, you can now start inspecting more about your app. A suggested next step is to add `app.Repl()` to the first line of the `BasicTest`, which will pop up a REPL window and allow you to interact with the app using various commands such as `tree`.
