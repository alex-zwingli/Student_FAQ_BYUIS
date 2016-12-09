# Project 2 Documentation

#### Michael Matthews | Ben Nelson | Alex Zwingli

Requirments

1. Create Database

For the first requriment we created all the necessary tables. However, we concluded that it would be more wise to split one of the tables into two different tables to further nominilize the data.

We split the degres table into two by seperating them as follows

- degree id
- degree name

The second degree table specified information regarding the degree coordinator

- degree coordinator 
- coordinator title
- coordinator office address
- PhD Education
- Masters Education
- Bachelors Education
- coordinator picture

The connection string for the Database is ```Data Source=DESKTOP-4RG0ECR\SQLEXPRESS;Initial Catalog=Degree;Integrated Security=True;Pooling=False```

2. Create a Login Page

A user can either login on the login page, or the can click on the register link to register. Upon registering, they will automatically be logged in.

3. Add Authentication

A user can only access the FAQ page if they are logged in. If they are not logged in, they will be redirected to the login page. Once a user logs in, they will still be able to see information regarding the degree, as well as information regarding the FAQ

4. FAQ functionality

Once in the FAQ page, a user can post a question or reply to a question.  Once the question is posted, the question cannot be deleted or edited. However, the answer can be changed over and over again (similar to a wiki) by any authorized user.

> Above and Beyond

It was suggested by the TAs that we should keep the following in mind when going above and beyond

How will you make their experience better? (user experience, consistency of layout, colors, image sizes, usability, controller code readability)?

With this in mind, we have made an effort to incorporate a number of different elements into the code, so that future developers would be able to easily use our code. For example, by including this markdown document, we've made it easier for the next developer to understand the overall flow of the project. 




