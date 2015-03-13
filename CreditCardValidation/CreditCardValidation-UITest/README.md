CreditCardValidation-UITest
============================

This sample is the companion code for the [Introduction to Xamarin.UITest](http://developer.xamarin.com/guides/testcloud/uitest/intro-to-uitest/) and the [Submitting Tests to Xamarin Test Cloud](http://developer.xamarin.com/guides/testcloud/submitting-to-testcoud) guides. It has some simple examples of tests written using Xamarin.UITest and includes a shell script that automates compiling the application and submitting it to Xamarin Test Cloud.

To get started with this project, it is necessary to log in to test cloud, create a new *test run*, receive your Xamarin Test Cloud API key, and the *device IDs* for the Android and iOS devices you would like to test on. The details on how to do this are discussed in the [Submitting Tests to Tesst Cloud](http://developer.xamarin.com/guides/testcloud/submitting/) guide.

Once you have these values, you can update one of the build scripts (described below) and upload the application and test to Test Cloud at the command line.


## About the Rakefile

This application uses [Rake](https://github.com/ruby/rake) to build and submit the application to Xamarin Test Cloud. The included `Rakefile` has the following tasks:

    $ rake -T
    rake build              # Compiles the Android and iOS projects
    rake clean              # Cleans the project, removing any artifacts from previous builds
    rake signing_info_file  # Rebuild the Android APK, sign it, and then generate the signing information file
    rake xtc                # Builds the application and then submits the APK and IPA to Xamarin Test Cloud

The Rakefile requires some environment variables set:

* `XTC_API_KEY` - this is the Test Cloud team API key
* `XTC_IOS_DEVICE_ID` - the device ID of your selected iOS devices
* `XTC_ANDROID_DEVICE_ID` - the device ID of your selected Android devices
* `XTC_USER` - the e-mail address that is a member of the Test Cloud team specified by the API key.

On simple way to set these variables is to create a text file called `init_vars.sh` with the following contents:

    #!/bin/sh
    export XTC_API_KEY=<YOUR API KEY>
    export XTC_IOS_DEVICE_ID=ce1f9b91
    export XTC_ANDROID_DEVICE_ID=fe27fcfe
    export XTC_USER=<YOUR EMAIL>

To set these environment variable, run `source init_vars` once, before running the Rake tasks.

## Generating the Signing Information File

One of the Rake tasks is an example of how to create the signing information file from a custom  keystore file is `creditcardvalidation-example.keystore` and it has a single key in it called `uitest_sample`. The password for the keystore file is *password1*, while the password for the key is *password2*. The task performs the following steps:

 1. Rebuild the Android APK
 2. Resign and zip align the APK using **./creditcardvalidation-example.keystore**
 3. Generate the signing information file.

To build a signing information file, run

    $ rake signing_info_file

### How the Keystore File was Created

To illustrate how to create the signing information file, the sample keystore has been provided with the following information:

	$ keytool -genkey -v -keystore creditcardvalidation-example.keystore -alias uitest_sample -keyalg RSA -keysize 2048 -validity 10000
	Enter keystore password:  
	Re-enter new password: 
	What is your first and last name?
	  [Unknown]:  Albert the Second
	What is the name of your organizational unit?
	  [Unknown]:  Documentation
	What is the name of your organization?
	  [Unknown]:  Xamarin
	What is the name of your City or Locality?
	  [Unknown]:  San Francisco
	What is the name of your State or Province?
	  [Unknown]:  CA
	What is the two-letter country code for this unit?
	  [Unknown]:  US
	Is CN=Albert the Second, OU=Documentation, O=Xamarin, L=San Francisco, ST=CA, C=US correct?
	  [no]:  yes


**Note:** In a production environment the keystore file should not be included in source code control. It contains confidential information that is used to sign your application and should be protected. The keystore is only included in this example for demonstration purposes.

