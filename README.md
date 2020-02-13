# Overview of "voLAWNteer"
My app will allow volunteers to help with lawn maintenance where homeowners cannot manage it themselves.

This app will support a data set of yards that need care, and volunteers may donate their time to help. Ads to market mower retailers or local mowing companies may support the cause financially. The yards will display on a rolling basis to keep the list of yards moving by dropping the most recently mowed yard to the bottom of the queue. Account logins will be reserved for admins and will allow features such as edit, delete, and lawn request approval. The site will have a request form to have a yard added to the group, which can be approved or denied by the admin. Listings will display pertinent criteria as well as a feature to mark a listing completed.

---
### Creation of app
* This project was created with C#/.NET using Entity Framework.

* Using the built-in bootstrap library for many components
    [Bootstrap](https://getbootstrap.com/docs/4.4/getting-started/introduction/)
---
* Below is a diagram showing the data relationships and tables
    [Entity Relationship](https://drive.google.com/file/d/1PYrx-NUQ8_k09fQ-L3izKPFz0ZM-_e3F/view?usp=sharing)

---
### Demo
1. Inside Visual Studio, and in the package manager, you should run: `Update-Database`
2. For the best demonstration of all of the features, a base profile has been built with starter data.

Use Login for authorized features:
username: admin@admin.com
password: Admin8*

#### Layout
1. Home page displays information about the application and the group. It also holds a form to submit a lawn for service and an "e-mail us" button which launches the native em-amil client and preloads an email. Once a lawn form is submitted, a personalized text alert confirmation will be sent (currently to a my number only due to Free Trial Software).
&nbsp;

![homeform](/homeform.gif)
&nbsp;

2. Queue page directs visitors to a queue of lawns and some volunteer statistics. Once a lawn is selected to be mowed, a text alert notification will be sent (currently to a my number only due to Free Trial Software)
&nbsp;

![queue](/queue.gif)
&nbsp;

3. Login/Register tab will allow admins to register or login as an admin and begin to use the authorized content of the app, including making changes to listings via a "Details" button on each listing in the Queue, and viewing the Pending tab where "approvals" can be made.
&nbsp;

4. the Pending tab takes admins to a page where they can approve or deny, as well as edit, lawn requests. Once a lawn is approved, a personalized text alert will be sent (currently to a my number only due to Free Trial Software)
    
![pending](/pending.jpg)
&nbsp;

![texts](/texts.jpg)
&nbsp;
    
---
### Downloading
1. First, fork the repo and clone it down.
2. Once it finished downloading, open the project from the level of viewing the Solution file
3. I recommend working in Visual Studio. From the package manager, run: Update-Database
4. Once this is complete, click the green Play button in the toolbar to run the app on your localhost
5. This will host the application in your browser.
6. To use authorized features, us the login credentials aforementioned.
---
### Author
Lance Pennington - [GitHub Repo](https://github.com/LanceP51/volawnteer)
---
### License
Copyright 2020 Lance Pennington
