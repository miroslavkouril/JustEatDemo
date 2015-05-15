# Technical questions

#### 1. How long did you spend on the coding test? What would you add to your solution if you had more time? If you didn't spend much time on the coding test then use this as an opportunity to explain what you would add.
I spent approximately 16 hours on the coding test. Here is the list of things which would be improved if the application was to be published on Play store:
 - Code refactoring
 - TitleBar design 
 - Postcode input validation and better info about invalid postcode 
 - Better progress animation while GPS is finding my current postcode 
 - Implement GPS functionality completely in Core library  
 - Improve speed of GPS reaction 
 - More UITests
 - Design of the first app screen - bottom part could be used to display some useful info 
 - Optimalise amount of data which are downloaded from web server, download icons of restaurants in separate thread 
 - Design of items in list of restaurants – now it contains only required data
 - Allow user to sort the list of displayed restaurants

#### 2. What was the most useful feature that was added to the latest version of your chosen language? Please include a snippet of code that shows how you've used it.
My favourite feature in C# 6 is *null-conditional operator (Elvis operator)*, please see the example below: 
```c#
locationFailedEvent?.Invoke();

// equals

if (locationFailedEvent != null)
{
    locationFailedEvent();
}
```

#### 3. How would you track down a performance issue in an application? Have you ever had to do this?
I would use **Xamarin Profiler**. They introduced this tool during last Xamarin Evolve conference (2014). I tried the preview version after its publishing, but I haven’t had to use it for commercial app yet.
Another approach would be to use **Xamarin Insights** reports and collect some important data using Track and TrackTime calls. I am already using Xamarin Insight in my apps to get information about crashes and usage of my apps.

#### 4. How would you improve the JUST EAT APIs that you just used?

 - Restaurants.Logo -> Now it is list of strings, but I can’t see any advantage of it, I would make that field just string
 - It returns empty list of restaurants when I use invalid postcode, I would prefer to return some indication about this problem to recognise if there are no restaurants in the area or whether I used wrong postcode.
 - RatingStars value is in range 0 – 6, I would preffer to use range 0 – 1. What happens to client apps when you decide to change number of stars?

#### 5. Please describe yourself using JSON.
```json
{
  "CandidateName": "Miroslav Kouril",
  "Summary": [
    "2,5 years of experience with Xamarin Android applications development",
    "Strong experience in Android SDK",
    "Familiar with TDD, Incremental build, SCRUM",
    "SOLID, Code smell, Clean Code"],
  "LookingForNewChallenge": true,
  "AndroidWorkExperience": [
    {
      "Company" : "Gradweb",
      "Position" : "Xamarin Android Developer",
      "DateFrom" : "2014-05-22T09:00:00.000Z",
      "DateTo" : "2015-05-01T17:30:00.000Z",
      "Description" : "I developed an Android mobile client to support the company’s recruitment system. I was the only person working on this project and therefore responsible for every aspect of the application like project architecture, UX/UI, service layer, testing, build environment, monitoring etc. The final version has been released and is waiting to be published."
    },
    {
      "Company" : "Systemart",
      "Position" : "Xamarin Android Developer",
      "DateFrom" : "2012-12-01T09:00:00.000Z",
      "DateTo" : "2014-05-21T18:00:00.000Z",
      "Description" : "I analysed and developed the Android application (using Xamarin Studio) for working time evidence. I was responsible for the whole software development lifecycle. I did everything from work time estimate, risk identification to implementation, creating test cases and presenting the results."
    }
  ],
  "AndroidProjects": [
    {
      "Name":"TalentSee",
      "LinkToScreenshots":"https://plus.google.com/photos/106016879153734431716/albums/6139439826792963569?authkey=CK6ky-36puzkYA"
    },
    {
      "Name":"Assembly Point Check",
      "LinkToScreenshots":"https://plus.google.com/photos/106016879153734431716/albums/6139440795836150097?authkey=CM3VxLL9ue_slQE"
    },
    {
      "Name":"VykazPrace",
      "LinkToScreenshots":"https://plus.google.com/photos/106016879153734431716/albums/6003554502362886689?authkey=CMyg7_XhjrTWsQE"
    },
    {
      "Name":"Public Tweets Reader",
      "LinkToScreenshots":"https://plus.google.com/photos/106016879153734431716/albums/6007728067749297985?authkey=CO7xroKSgYnAEw"
    },
    {
      "Name":"RSS Reader",
      "LinkToScreenshots":"https://plus.google.com/photos/106016879153734431716/albums/6002192169616972833?authkey=CNLrwKns8OT1Vw"
    }
  ],
  "AlwaysInAGoodMood": true,
}
```
