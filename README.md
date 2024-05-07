# Software Engineering Formulatrix Bootcamp
Here lies the base repo for the Formulatrix Software Engineering Bootcamp. C# Ecosystem will be used here

## Progress
* 1st day --> Build initial repo for the rest of the ongoing bootcamp, making an example of the branch, and installing the essential tools for the bootcamp (.NET(still dont know what is this), C# VSCode Extension, and SourceTree(Just like towergit)). 

    For the first creation of the C# Project structure, the workflow of the creation is as follow
    `solution(sln) --> project(.csproj) --> assembly --> [.exe, .dll]`

    Now for adding a new solution blueprint, how we do it? Below are the terminal command for it
    ```sh
    dotnet new sln -n "filename"
    ```
    After we make the solution, we can make the project based on those blueprint(solution) wih this command at the shell
    ```sh
    dotnet new 'console' -lang "C#" -n "ProjectName" -o "CSPROJName"
    ```

    a-fact : in C#, everything needs to be done in class, just like Java I guess. I mean, maybe thats why Java is going to extinct
    a-fact : In default, variable in class C# is protected, no one from outside can access those the trick is to make a function to make them public and access them there
    a-fact again : in C#, every function or method in C# in this case, need everytime to evaluate each class with a type, so if you want a even need to return 

* 2nd Day --> Another day continuing C# project inisialisation. Today we focus more using namespace and modulatization of each function in the project. 
