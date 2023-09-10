﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace kwiz_backend.Data.Migrations
{
    /// <inheritdoc />
    public partial class Seed_Technologies : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string[]>(
                name: "Tags",
                table: "Technologies",
                type: "text[]",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Technologies",
                columns: new[] { "Id", "Description", "Name", "Tags", "Type" },
                values: new object[,]
                {
                    { new Guid("011d6a83-36f1-4ebc-843f-49509a883fe6"), "Ruby is a dynamic, interpreted, reflective, object-oriented, general-purpose programming language.", "Ruby", new[] { "Ruby", "General Purpose", "Dynamic" }, "Programming Language" },
                    { new Guid("01db026e-c96b-48b8-aac3-4c98df477435"), "Qt is a C++ framework for developing cross-platform applications, including user interfaces and device-specific features.", "Qt", new[] { "C++", "Desktop" }, "Framework" },
                    { new Guid("060e77b5-e1ef-499f-8124-08a010f6c1f4"), "Vim script is a scripting language used for customizing and extending the Vim text editor.", "Vim script", new[] { "Vim", "Scripting", "Text Editor" }, "Programming Language" },
                    { new Guid("08b4d4fa-b50e-416d-a21a-9811b9cd3933"), "Eclipse is an integrated development environment (IDE) used in computer programming.", "Eclipse", new[] { "IDE", "Java", "Open Source" }, "Tool" },
                    { new Guid("0ccc4600-a3ed-4660-887c-669207bd1a66"), "PyTorch is an open-source machine learning framework that provides a flexible, dynamic approach to building and training models.", "PyTorch", new[] { "Python", "Machine Learning", "AI" }, "Framework" },
                    { new Guid("0d58aab8-907b-4037-9e5e-207177c2b190"), "NestJS is a TypeScript-based Node.js framework for building efficient and scalable server-side applications.", "NestJS", new[] { "TypeScript", "Web", "Backend" }, "Framework" },
                    { new Guid("0e68b026-96c3-487c-8c61-c1466042dd97"), "OCaml is a general-purpose, functional, and imperative programming language.", "OCaml", new[] { "OCaml", "Functional", "General Purpose" }, "Programming Language" },
                    { new Guid("0faca12c-9fb7-4522-be57-4b5c8262a434"), "Symfony is a set of reusable PHP components and a web application framework that follows the Model-View-Controller (MVC) pattern.", "Symfony", new[] { "PHP", "Web", "Backend", "MVC" }, "Framework" },
                    { new Guid("10024547-e79d-45e5-a272-24b495cbe1e6"), "PureScript is a strongly-typed functional programming language that compiles to JavaScript.", "PureScript", new[] { "PureScript", "Functional", "TypeScript" }, "Programming Language" },
                    { new Guid("1131129a-60e4-4cc8-9441-136ac78006da"), "A data structure is a way of organizing and storing data in a computer so that it can be used efficiently.", "Data Structure", new[] { "Data Structure", "Organization", "Efficiency" }, "Concept" },
                    { new Guid("129735b5-bfb6-438a-befb-3e5df56aa98f"), "Ruby Grape is a micro-framework for creating REST-like APIs in Ruby.", "Ruby Grape", new[] { "Ruby", "Web", "API" }, "Framework" },
                    { new Guid("13239d1b-4690-4b8f-b63f-113bdd1488d2"), "Haskell is a functional programming language that emphasizes a concise, declarative coding style.", "Haskell", new[] { "Haskell", "Functional", "Concise" }, "Programming Language" },
                    { new Guid("139cef88-4096-4053-b523-910b0341bad7"), "JIRA is a proprietary issue tracking product developed by Atlassian that allows bug tracking and agile project management.", "JIRA", new[] { "Project Management", "Issue Tracking", "Atlassian" }, "Tool" },
                    { new Guid("13da0360-ff19-4c98-96e8-9b7b6d942640"), "Sublime Text is a proprietary cross-platform source code editor with a Python application programming interface (API).", "Sublime Text", new[] { "Editor", "Text Editor", "Proprietary" }, "Tool" },
                    { new Guid("15d5f9f9-9e19-417f-9822-f79b65d80217"), "Android Studio is the official integrated development environment (IDE) for Android application development.", "Android Studio", new[] { "IDE", "Android", "Google" }, "Tool" },
                    { new Guid("195392c3-7cf6-413e-b39c-4be18eaa2bac"), "Confluence is a web-based corporate wiki application developed by Atlassian.", "Confluence", new[] { "Collaboration", "Wiki", "Atlassian" }, "Tool" },
                    { new Guid("199883e4-d552-4fb2-8f87-fe239311eb43"), "Git is a distributed version control system for tracking changes in source code during software development.", "Git", new[] { "Version Control", "Git", "Open Source" }, "Tool" },
                    { new Guid("1e5c807f-08d4-464c-9057-f8819748848a"), "Atom is a free and open-source text and source code editor for macOS, Linux, and Microsoft Windows.", "Atom", new[] { "Editor", "Text Editor", "Open Source" }, "Tool" },
                    { new Guid("1fe00da7-4683-4e59-b231-42be49f5fe59"), "Vagrant is an open-source software product for building and maintaining portable virtual software development environments.", "Vagrant", new[] { "Virtualization", "Development Environment", "Open Source" }, "Tool" },
                    { new Guid("20735ad2-7dff-472b-91ff-659d99fb5b5e"), "Visual Studio Online is a web-based integrated development environment (IDE) for software developers.", "Visual Studio Online", new[] { "IDE", "Microsoft", "Web" }, "Tool" },
                    { new Guid("2156463e-432a-4937-887c-d0d9a9e641e0"), "Machine learning is a subset of artificial intelligence that involves training computers to learn from data and improve their performance over time.", "Machine Learning", new[] { "Machine Learning", "Artificial Intelligence", "Data" }, "Concept" },
                    { new Guid("222aa98d-29f3-4552-bc42-e765c6000eb2"), "Lua is a lightweight, high-level, multi-paradigm programming language designed primarily for embedded systems and games.", "Lua", new[] { "Lua", "Embedded Systems", "Scripting" }, "Programming Language" },
                    { new Guid("22d11d39-7410-4d12-86e1-619e42248dd9"), "PostScript is a page description language and programming language used primarily in the electronic and desktop publishing areas.", "PostScript", new[] { "PostScript", "Page Description", "Publishing" }, "Programming Language" },
                    { new Guid("23249c74-81c9-47e9-9084-52367ba81319"), "Phoenix is a web framework for building real-time, fault-tolerant, and distributed systems using Elixir.", "Phoenix", new[] { "Elixir", "Web", "Real-Time" }, "Framework" },
                    { new Guid("2330e078-a8d7-444f-9647-bffb419f42e3"), "Scratch is a visual programming language and online community where users can create their own interactive stories, games, and animations.", "Scratch", new[] { "Scratch", "Visual", "Education" }, "Programming Language" },
                    { new Guid("26dcd089-f586-45a4-808f-711896d84723"), "Xcode is an integrated development environment (IDE) for macOS containing a suite of software development tools.", "Xcode", new[] { "IDE", "Apple", "macOS" }, "Tool" },
                    { new Guid("277baf27-7856-4f57-a86c-b0f4e1519017"), "Slim is a PHP micro framework that's ideal for building simple, yet powerful web applications and APIs.", "Slim", new[] { "PHP", "Web", "Backend" }, "Framework" },
                    { new Guid("28c4f563-2efe-4f34-8df9-c1baeac32992"), "Django REST framework is a powerful toolkit for building Web APIs in Django applications.", "Django REST framework", new[] { "Python", "Web", "API" }, "Framework" },
                    { new Guid("2a0c7573-f7ae-4ef5-a923-71ac5fa548b6"), "Koa is a modern web framework for Node.js that aims to be smaller, more expressive, and more robust.", "Koa", new[] { "JavaScript", "Web", "Backend" }, "Framework" },
                    { new Guid("305e9c09-2c90-4bad-ab6b-ae7570ad684b"), "Io is a small, prototype-based programming language inspired by Smalltalk, Lisp, and other languages.", "Io", new[] { "Io", "Prototype-Based", "Small" }, "Programming Language" },
                    { new Guid("356ea8c4-c50c-479a-9c16-9c06e4dbfcd8"), "Ionic is a popular open-source framework for building cross-platform mobile applications using web technologies like HTML, CSS, and JavaScript.", "Ionic", new[] { "JavaScript", "Mobile" }, "Framework" },
                    { new Guid("365091b8-7e20-4527-8e2d-5363692c8c7f"), "Visual Studio Code is a free source-code editor made by Microsoft for Windows, Linux, and macOS.", "Visual Studio Code", new[] { "IDE", "Editor", "Microsoft" }, "Tool" },
                    { new Guid("366483ca-2b61-4bb3-9f09-7e94f20e9a83"), "Code review is a systematic examination of computer source code. It is intended to find mistakes overlooked in initial development.", "Code Review", new[] { "Code Review", "Quality Assurance", "Collaboration" }, "Concept" },
                    { new Guid("389c99c5-7714-468d-9796-d6bc816b82e4"), "Ruby on Rails is a web application framework written in Ruby that follows the Model-View-Controller (MVC) architectural pattern.", "Ruby on Rails", new[] { "Ruby", "Web", "MVC" }, "Framework" },
                    { new Guid("38b07b1f-b7f5-477b-9fd7-893814d03a4c"), "Turing is a Pascal-like programming language developed for teaching programming concepts to beginners.", "Turing", new[] { "Turing", "Education", "Teaching" }, "Programming Language" },
                    { new Guid("41c51976-8884-488c-a36e-3d799b50832e"), "Continuous Deployment is a software development practice where every code change that passes automated testing is automatically deployed to production.", "Continuous Deployment", new[] { "Continuous Deployment", "Automation", "Production" }, "Concept" },
                    { new Guid("42ca9979-6a09-4ff1-9f22-c679e7718d80"), "Nuxt.js is a higher-level framework built on top of Vue.js, designed for creating universal and single page applications.", "Nuxt.js", new[] { "Vue.js", "JavaScript", "Web", "Frontend" }, "Framework" },
                    { new Guid("434e2e82-3669-4f50-bbe7-fbc9fe644caf"), "Spring is a Java framework that provides comprehensive infrastructure support for building Java applications.", "Spring", new[] { "Java", "Web", "Backend" }, "Framework" },
                    { new Guid("462bd4a5-e94b-42b7-b9b7-e8396061ec7a"), "Swift is a general-purpose, multi-paradigm programming language developed by Apple Inc. for iOS, iPadOS, macOS, watchOS, tvOS, and Linux.", "Swift", new[] { "Swift", "Multi-Paradigm", "iOS" }, "Programming Language" },
                    { new Guid("47741c56-6b1a-44fd-bdd4-ddb7e3d7f724"), "Perl is a high-level, general-purpose, interpreted, dynamic programming language.", "Perl", new[] { "Perl", "General Purpose", "Scripting" }, "Programming Language" },
                    { new Guid("481932a6-504b-4ba0-a14c-606833072299"), "Groovy is a dynamic programming language that runs on the Java Virtual Machine and can be used as both a programming language and a scripting language.", "Groovy", new[] { "Groovy", "Dynamic", "JVM" }, "Programming Language" },
                    { new Guid("497a7757-66fe-46ec-89ba-9eb2895b9768"), "DevOps is a set of practices that combines software development (Dev) and IT operations (Ops) to shorten the software development life cycle and improve deployment frequency.", "DevOps", new[] { "DevOps", "Collaboration", "Automation" }, "Concept" },
                    { new Guid("4a1ee378-e616-49ca-b884-cbc23a3344b0"), "Version control is a system that records changes to a file or set of files over time, so that you can recall specific versions later.", "Version Control", new[] { "Version Control", "Collaboration", "History" }, "Concept" },
                    { new Guid("4c2ad544-8336-47e4-82a8-80d36e8cbaa7"), "Laravel is a PHP web application framework known for its elegant syntax and features like routing, authentication, and caching.", "Laravel", new[] { "PHP", "Web", "Backend" }, "Framework" },
                    { new Guid("4eee617c-7f4e-46a0-b783-b1b8073d346c"), "Maxima is a computer algebra system based on a 1982 version of Macsyma.", "Maxima", new[] { "Maxima", "Algebra", "Mathematics" }, "Programming Language" },
                    { new Guid("4f560415-c2a9-4c16-a021-b547c28e416b"), "React is a JavaScript library for building user interfaces, particularly single-page applications.", "React", new[] { "JavaScript", "Web", "Frontend" }, "Framework" },
                    { new Guid("52b7f637-109a-491d-971e-7201f7e2bdb0"), "Zig is a general-purpose programming language designed for robustness, optimality, and maintainability.", "Zig", new[] { "Zig", "General Purpose", "Robust" }, "Programming Language" },
                    { new Guid("541e9968-d017-4bf6-a41a-22b667cff92e"), "Nim is a statically typed, imperative programming language that focuses on performance, portability, and expressiveness.", "Nim", new[] { "Nim", "Statically Typed", "Performance" }, "Programming Language" },
                    { new Guid("5669fe67-b55e-4f32-b63e-8d21e528f0fa"), "A database is an organized collection of structured information, or data, typically stored electronically in a computer system.", "Database", new[] { "Database", "Data Storage", "Structured" }, "Concept" },
                    { new Guid("5adf86fc-dbe1-4b0c-8a05-45b4f14a3238"), "Objective-C is a general-purpose, object-oriented programming language used by Apple for the macOS and iOS operating systems.", "Objective-C", new[] { "Objective-C", "Object-Oriented", "Apple" }, "Programming Language" },
                    { new Guid("5b2dd237-e0ea-442e-b200-4feec9a91a77"), "J is a high-level, interpreted programming language, primarily used for mathematical and statistical analysis.", "J", new[] { "J", "Mathematical", "Interpreted" }, "Programming Language" },
                    { new Guid("5c8566bc-c29d-4001-a190-abb02006e369"), "RubyMotion is a framework for building native applications on iOS, Android, macOS, and more using the Ruby programming language.", "RubyMotion", new[] { "Ruby", "Mobile" }, "Framework" },
                    { new Guid("5fc7e80c-b54d-49f7-92ee-afd863e8ea49"), "Ember.js is a JavaScript framework for building ambitious web applications that handles the boilerplate and provides conventions.", "Ember.js", new[] { "JavaScript", "Web", "Frontend" }, "Framework" },
                    { new Guid("6383cbb8-11ef-415b-accd-b0c97d6da9be"), "Python is an interpreted, high-level and general-purpose programming language.", "Python", new[] { "Python", "General Purpose", "Interpreted" }, "Programming Language" },
                    { new Guid("66046545-0747-4369-a71c-2e284914edbb"), "PowerShell is a task automation and configuration management framework from Microsoft, consisting of a command-line shell and associated scripting language.", "PowerShell", new[] { "PowerShell", "Automation", "Microsoft" }, "Programming Language" },
                    { new Guid("6a41a0b6-723b-4939-96c6-f2324d7310ef"), "Big data refers to extremely large datasets that may be analyzed computationally to reveal patterns, trends, and associations.", "Big Data", new[] { "Big Data", "Data Analysis", "Patterns" }, "Concept" },
                    { new Guid("6cecbbc6-f43d-466d-9650-b8d7161cf225"), "Continuous Integration (CI) is a software development practice where code changes are automatically built, tested, and integrated into the shared repository.", "Continuous Integration", new[] { "Continuous Integration", "Automation", "Testing" }, "Concept" },
                    { new Guid("6d48a7d5-cc70-48df-8d4e-acae03ad2b62"), "Selenium is a portable framework for testing web applications. Selenium provides a playback tool for authoring functional tests.", "Selenium", new[] { "Testing", "Web", "Automated Testing" }, "Tool" },
                    { new Guid("7225b812-857f-4017-9282-95dba1d5affd"), "User Experience (UX) refers to a person's emotions and attitudes about using a particular product, system, or service.", "User Experience (UX)", new[] { "User Experience", "Design", "Emotions" }, "Concept" },
                    { new Guid("756df21d-ef11-49ab-b0ce-791905e52dfe"), "JavaScript is a high-level, interpreted scripting language used to create dynamic and interactive websites.", "JavaScript", new[] { "JavaScript", "Web", "Scripting" }, "Programming Language" },
                    { new Guid("78ea6a5a-4708-4904-bf20-53526e9d62da"), "PL/I is a procedural, imperative computer programming language designed for scientific, engineering, business, and systems programming applications.", "PL/I", new[] { "PL/I", "Procedural", "Scientific" }, "Programming Language" },
                    { new Guid("7b686076-f7dd-4f69-97c2-d2149605e0ea"), "R is a programming language and free software environment used for statistical computing and graphics.", "R", new[] { "R", "Statistical Computing", "Data Analysis" }, "Programming Language" },
                    { new Guid("802ee8d3-3039-46c1-ac6a-45db7a20e98c"), "C++ is a general-purpose programming language created as an extension of the C programming language, providing object-oriented and generic programming features.", "C++", new[] { "C++", "Object-Oriented", "Systems" }, "Programming Language" },
                    { new Guid("82afe9a3-a537-443b-97c2-0eda2f8a6343"), "GitHub is a web-based platform for version control and collaboration using Git.", "GitHub", new[] { "Version Control", "Collaboration", "Web" }, "Tool" },
                    { new Guid("8664d04c-390f-4c10-bbd8-60867036d06c"), "SAS is a software suite used for advanced analytics, business intelligence, and data management.", "SAS", new[] { "SAS", "Analytics", "Data Management" }, "Programming Language" },
                    { new Guid("8acea1d6-7821-4d68-ad0f-50b342a2b877"), "X10 is a high-level programming language that is designed for high-performance, high-productivity computing.", "X10", new[] { "X10", "High-Performance", "Concurrent" }, "Programming Language" },
                    { new Guid("8b3c3780-4b87-4305-90cd-fd6e4e473a27"), "IntelliJ IDEA is a powerful Java integrated development environment (IDE) for developing computer software.", "IntelliJ IDEA", new[] { "IDE", "Java", "JetBrains" }, "Tool" },
                    { new Guid("8b6b4413-d674-4af2-9e38-e67e4c0324a3"), "Express.js is a fast, unopinionated, minimalist web framework for Node.js, designed for building web applications and APIs.", "Express.js", new[] { "JavaScript", "Web", "Backend" }, "Framework" },
                    { new Guid("8ff74648-d898-4c4a-a76e-c910368cfc77"), "Go (also known as Golang) is an open-source programming language created by Google. It is statically typed, compiled, and focuses on simplicity and efficiency.", "Go", new[] { "Go", "Static Typing", "Efficiency" }, "Programming Language" },
                    { new Guid("91351a43-7b88-463c-b4d8-fcb33221ae25"), "REXX is an interpreted language that is used primarily for text processing.", "REXX", new[] { "REXX", "Interpreted", "Text Processing" }, "Programming Language" },
                    { new Guid("91c990ae-4192-4cdd-991d-9e22c90a764b"), "An API (Application Programming Interface) is a set of rules and protocols that allows different software applications to communicate with each other.", "API", new[] { "API", "Communication", "Integration" }, "Concept" },
                    { new Guid("9615dc85-c0be-4c2f-a4b4-ffe5b222298f"), "PHP is a server-side scripting language designed for web development but also used as a general-purpose programming language.", "PHP", new[] { "PHP", "Web", "Scripting" }, "Programming Language" },
                    { new Guid("96dfec93-9b99-43d1-947f-baf7b1221647"), "Unit testing is a software testing method where individual units or components of a software are tested in isolation.", "Unit Testing", new[] { "Unit Testing", "Testing", "Components" }, "Concept" },
                    { new Guid("97d7254e-ffc3-4f0b-931d-5c2a71b77e3d"), "ASP.NET is a web framework developed by Microsoft for building dynamic web applications, web services, and websites.", "ASP.NET", new[] { "C#", ".NET", "Web", "Backend" }, "Framework" },
                    { new Guid("997e36ff-0c39-45c6-b0d7-844dbe61b4f1"), "Java is a general-purpose programming language that is class-based, object-oriented, and designed to have as few implementation dependencies as possible.", "Java", new[] { "Java", "General Purpose", "Object-Oriented" }, "Programming Language" },
                    { new Guid("9adfe3e8-6c62-4a91-9574-4dd8b0c31a85"), "Slack is a proprietary business communication platform that offers many IRC-style features.", "Slack", new[] { "Communication", "Collaboration", "Messaging" }, "Tool" },
                    { new Guid("9bca5879-015b-4d68-a0e5-4308d6c084e3"), "Erlang is a general-purpose, concurrent, functional programming language used primarily in telecommunications and other high-availability systems.", "Erlang", new[] { "Erlang", "Concurrent", "Functional" }, "Programming Language" },
                    { new Guid("9c4acd31-81ca-448e-a43e-69bc86043b5a"), "Trello is a web-based list-making application originally made by Fog Creek Software in 2011, that was spun out to form the basis of a separate company in 2014.", "Trello", new[] { "Project Management", "Agile", "Productivity" }, "Tool" },
                    { new Guid("a2537e9e-4afc-4ec8-8b01-f79373e85810"), "Cybersecurity is the practice of protecting computer systems, networks, and data from theft, damage, or unauthorized access.", "Cybersecurity", new[] { "Cybersecurity", "Protection", "Networks" }, "Concept" },
                    { new Guid("a286a4a7-3332-4741-81a3-8e3fe81c4d40"), "Julia is a high-level, high-performance programming language for technical computing, with syntax that is familiar to users of other technical computing environments.", "Julia", new[] { "Julia", "Technical Computing", "Performance" }, "Programming Language" },
                    { new Guid("a36c3a13-84d1-456e-a1e5-28e13e7dba05"), "Vue.js is a progressive JavaScript framework for building user interfaces, designed to be incrementally adoptable.", "Vue.js", new[] { "JavaScript", "Web", "Frontend" }, "Framework" },
                    { new Guid("a4ec1179-c366-492c-aa28-1c1271eee35d"), "Feathers is a web framework for building real-time applications using JavaScript or TypeScript across various platforms.", "Feathers", new[] { "JavaScript", "Web", "Real-Time" }, "Framework" },
                    { new Guid("a61b823e-5663-42a5-936c-aea459564c3b"), "Django is a high-level Python web framework that encourages rapid development and clean, pragmatic design.", "Django", new[] { "Python", "Web", "MVC" }, "Framework" },
                    { new Guid("a9efcc1f-1969-46d7-abbe-c1569fef6e6c"), "C is a general-purpose, procedural computer programming language supporting structured programming, lexical variable scope, and recursion, with a static type system.", "C", new[] { "C", "Procedural", "Low-Level" }, "Programming Language" },
                    { new Guid("aabf86ff-a4fb-4c86-8074-e7e313afb3c4"), "Postman is a collaboration platform for API development that simplifies the process of developing APIs that allow software to communicate.", "Postman", new[] { "API Development", "Testing", "Collaboration" }, "Tool" },
                    { new Guid("b2410fdd-8e5b-4cef-ab61-07ae930b1962"), "Scala is a general-purpose programming language that integrates functional and object-oriented programming.", "Scala", new[] { "Scala", "General Purpose", "Functional" }, "Programming Language" },
                    { new Guid("b2d3f3db-aad8-41c9-94bd-4ae8775ebfdd"), "Rust is a systems programming language that aims to provide the speed of C and C++ while also focusing on memory safety and thread safety.", "Rust", new[] { "Rust", "Systems", "Memory Safety" }, "Programming Language" },
                    { new Guid("b3d02b02-853a-4c8c-84ff-8d330d4d6de9"), "Responsive design is an approach to web design that makes web pages render well on a variety of devices and window or screen sizes.", "Responsive Design", new[] { "Responsive Design", "Web", "User Experience" }, "Concept" },
                    { new Guid("b408faa6-85b8-42e9-8347-bef81c7ff5ee"), "PyCharm is an integrated development environment (IDE) used in computer programming for Python language.", "PyCharm", new[] { "IDE", "Python", "JetBrains" }, "Tool" },
                    { new Guid("b4d4a790-79fc-42e2-8fc3-cbc886432802"), "Jupyter Notebook is an open-source web application that allows you to create and share documents that contain live code, equations, visualizations, and narrative text.", "Jupyter Notebook", new[] { "Notebook", "Python", "Data Science" }, "Tool" },
                    { new Guid("b65bcebb-ec23-4c33-962f-ba6b6bb4632e"), "COBOL is a compiled English-like computer programming language designed for business use.", "Cobol", new[] { "COBOL", "Business", "Compiled" }, "Programming Language" },
                    { new Guid("b82c7046-9efb-42be-8892-39d011b53e26"), "npm is a package manager for the JavaScript programming language.", "npm", new[] { "Package Manager", "JavaScript", "Node.js" }, "Tool" },
                    { new Guid("b9fe4e04-72f5-4638-a293-869f0eaaad18"), ".NET Core is an open-source, cross-platform framework for building modern, cloud-based, and internet-connected applications.", ".NET Core", new[] { ".NET", "C#", "Web", "Backend" }, "Framework" },
                    { new Guid("baaddf2f-bdd8-460e-b581-3ae086b4a92a"), "Quasar Framework is a high-performance, responsive design framework for building websites, mobile apps, and Electron apps using Vue.js.", "Quasar Framework", new[] { "Vue.js", "JavaScript", "Web", "Mobile" }, "Framework" },
                    { new Guid("bc732dad-8593-4652-82c2-5174efa777f8"), "An algorithm is a step-by-step procedure or formula for solving a problem or accomplishing a task.", "Algorithm", new[] { "Algorithm", "Problem Solving", "Procedure" }, "Concept" },
                    { new Guid("bf0ceb2a-4173-4679-8248-eb5caa521930"), "TypeScript is a strict syntactical superset of JavaScript that adds optional static typing, interfaces, and other advanced features.", "TypeScript", new[] { "TypeScript", "JavaScript", "Static Typing" }, "Programming Language" },
                    { new Guid("bf972265-1f03-416b-9f19-3a5163573063"), "Meteor is a full-stack JavaScript framework for building real-time web applications, including both the front-end and back-end.", "Meteor", new[] { "JavaScript", "Web", "Full-Stack" }, "Framework" },
                    { new Guid("c15db080-fedc-456c-91eb-791e92bddd52"), "NetBeans is an integrated development environment (IDE) for Java. It supports development of all Java application types.", "NetBeans", new[] { "IDE", "Java", "Open Source" }, "Tool" },
                    { new Guid("c18854f0-6152-42f0-8de8-73878c29c89c"), "ML is a general-purpose functional programming language developed by Robin Milner and others in the early 1970s.", "ML", new[] { "ML", "Functional", "General Purpose" }, "Programming Language" },
                    { new Guid("c372b7c2-4e09-4877-a6d2-8ae995e8df11"), "Pascal is an influential imperative and procedural programming language, designed in the late 1960s as a small and efficient language intended to encourage good programming practices.", "Pascal", new[] { "Pascal", "Imperative", "Efficient" }, "Programming Language" },
                    { new Guid("c532d499-1ee5-45a4-97a7-993f150edbcb"), "Kotlin is a statically typed programming language that runs on the Java Virtual Machine and also can be compiled to JavaScript source code or uses the LLVM compiler infrastructure.", "Kotlin", new[] { "Kotlin", "Static Typing", "JVM" }, "Programming Language" },
                    { new Guid("c7d5d113-3c84-4386-bc56-ea8677cb372a"), "Artificial intelligence (AI) is the simulation of human intelligence in machines that are capable of performing tasks that typically require human intelligence.", "Artificial Intelligence", new[] { "Artificial Intelligence", "Simulation", "Automation" }, "Concept" },
                    { new Guid("c95f9540-c170-4c53-829b-9c38b261528f"), "TensorFlow is an open-source machine learning framework developed by Google for building and training neural network models.", "TensorFlow", new[] { "Python", "Machine Learning", "AI" }, "Framework" },
                    { new Guid("cc4117fd-7818-44d7-99a5-6c53c154d4f8"), "Haxe is a high-level, open-source programming language that can be compiled to various target languages, including JavaScript, C++, and more.", "Haxe", new[] { "Haxe", "High-Level", "Cross-Compilation" }, "Programming Language" },
                    { new Guid("ce7b2acf-ae00-49c5-b40f-f9fb3942f14f"), "Code quality refers to the overall robustness, maintainability, readability, and performance of a software codebase.", "Code Quality", new[] { "Code Quality", "Robustness", "Maintainability" }, "Concept" },
                    { new Guid("d3f9d2c7-a635-4f6b-a57c-da844171fa64"), "Agile is an iterative approach to software development that emphasizes flexibility, collaboration, and customer feedback.", "Agile", new[] { "Agile", "Methodology", "Iterations" }, "Concept" },
                    { new Guid("d8f36aff-6678-40e5-ac3f-40c3a6ae283d"), "Angular is a platform and framework for building client-side applications using TypeScript and the Model-View-Controller (MVC) pattern.", "Angular", new[] { "TypeScript", "Web", "Frontend", "MVC" }, "Framework" },
                    { new Guid("ddba0465-b9a8-408d-b289-f8c95752639b"), "Continuous monitoring involves the regular collection and analysis of data to evaluate the performance and security of a system.", "Continuous Monitoring", new[] { "Continuous Monitoring", "Performance", "Security" }, "Concept" },
                    { new Guid("e1d394bb-b450-47de-a788-4f99bc55fa9f"), "CMake is an open-source, cross-platform family of tools designed to build, test, and package software.", "CMake", new[] { "Build Tool", "Cross-Platform", "Open Source" }, "Tool" },
                    { new Guid("e214d688-12ab-42be-9448-235edb15caf5"), "Code refactoring is the process of restructuring existing computer code without changing its external behavior.", "Code Refactoring", new[] { "Code Refactoring", "Code Improvement", "Restructuring" }, "Concept" },
                    { new Guid("e2ad8d3b-624b-45dc-9b24-228c0a96a982"), "C# is a general-purpose, multi-paradigm programming language encompassing strong typing, lexically scoped, imperative, declarative, functional, generic, object-oriented, and component-oriented programming disciplines.", "C#", new[] { "C#", "General Purpose", "Object-Oriented" }, "Programming Language" },
                    { new Guid("e5cf94d8-6417-459c-8a54-e30ca386fdb6"), "User Interface (UI) encompasses the visual elements, controls, and layouts through which a user interacts with a software or hardware.", "User Interface (UI)", new[] { "User Interface", "Design", "Interactions" }, "Concept" },
                    { new Guid("e6bccde8-d5ce-42bc-be0f-2b4580a34400"), "ASP.NET Core is the cross-platform version of ASP.NET, suitable for building modern web applications and APIs.", "ASP.NET Core", new[] { "C#", ".NET", "Web", "Backend" }, "Framework" },
                    { new Guid("e8e6db43-6d3c-469a-9033-9acd7e42147e"), "Visual Studio is an integrated development environment (IDE) developed by Microsoft.", "Visual Studio", new[] { "IDE", "Microsoft", "Windows" }, "Tool" },
                    { new Guid("f1011667-d18b-44c8-90e2-18e5d85e1be1"), "Tcl is a high-level, dynamic programming language often used for rapid prototyping and scripting.", "Tcl", new[] { "Tcl", "Scripting", "Dynamic" }, "Programming Language" },
                    { new Guid("f1dbf65b-ce4d-4161-bedd-656268546e8a"), "Sails.js is a full-featured MVC framework for building web applications and APIs using Node.js.", "Sails.js", new[] { "JavaScript", "Web", "Full-Stack", "MVC" }, "Framework" },
                    { new Guid("f2ecade4-4a25-419d-91b9-9cff1ce31853"), "Dart is a programming language designed for building web, server, and mobile applications.", "Dart", new[] { "Dart", "Web", "Mobile" }, "Programming Language" },
                    { new Guid("f520ae50-b179-4a66-b3b2-f237ed0971f5"), "Visual Basic is a third-generation event-driven programming language from Microsoft.", "Visual Basic", new[] { "Visual Basic", "Microsoft", "Event-Driven" }, "Programming Language" },
                    { new Guid("f7fefa93-c53e-4997-a2bb-2f40ba032a43"), "Cloud computing is the delivery of computing services—servers, storage, databases, networking, software, over the Cloud (Internet).", "Cloud Computing", new[] { "Cloud Computing", "Services", "Internet" }, "Concept" },
                    { new Guid("f94e3f88-b182-4c23-b821-45443ef706b0"), "Ring is a dynamic and general-purpose programming language that is designed to be simple and easy to learn.", "Ring", new[] { "Ring", "General Purpose", "Dynamic" }, "Programming Language" },
                    { new Guid("f9830aec-653c-4bd1-83a6-d1815e1dac82"), "Flask is a lightweight Python web framework that's easy to use and designed to make getting started quick and easy.", "Flask", new[] { "Python", "Web", "Backend" }, "Framework" },
                    { new Guid("fb60d668-e9fb-4883-9c91-0028bddc066d"), "Docker is a set of platform as a service (PaaS) products that use OS-level virtualization to deliver software in packages called containers.", "Docker", new[] { "Containerization", "Virtualization", "DevOps" }, "Tool" },
                    { new Guid("ff32ab4a-be7c-4c53-959f-9e40ecb019f0"), "Ansible is an open-source automation tool that automates software provisioning, configuration management, and application deployment.", "Ansible", new[] { "Automation", "Configuration Management", "DevOps" }, "Tool" },
                    { new Guid("ff991007-6d77-4166-9241-47b8f41e4954"), "Webpack is an open-source JavaScript module bundler. It takes modules with dependencies and generates static assets representing those modules.", "Webpack", new[] { "Module Bundler", "JavaScript", "Build Tool" }, "Tool" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("011d6a83-36f1-4ebc-843f-49509a883fe6"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("01db026e-c96b-48b8-aac3-4c98df477435"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("060e77b5-e1ef-499f-8124-08a010f6c1f4"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("08b4d4fa-b50e-416d-a21a-9811b9cd3933"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("0ccc4600-a3ed-4660-887c-669207bd1a66"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("0d58aab8-907b-4037-9e5e-207177c2b190"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("0e68b026-96c3-487c-8c61-c1466042dd97"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("0faca12c-9fb7-4522-be57-4b5c8262a434"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("10024547-e79d-45e5-a272-24b495cbe1e6"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("1131129a-60e4-4cc8-9441-136ac78006da"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("129735b5-bfb6-438a-befb-3e5df56aa98f"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("13239d1b-4690-4b8f-b63f-113bdd1488d2"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("139cef88-4096-4053-b523-910b0341bad7"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("13da0360-ff19-4c98-96e8-9b7b6d942640"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("15d5f9f9-9e19-417f-9822-f79b65d80217"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("195392c3-7cf6-413e-b39c-4be18eaa2bac"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("199883e4-d552-4fb2-8f87-fe239311eb43"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("1e5c807f-08d4-464c-9057-f8819748848a"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("1fe00da7-4683-4e59-b231-42be49f5fe59"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("20735ad2-7dff-472b-91ff-659d99fb5b5e"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("2156463e-432a-4937-887c-d0d9a9e641e0"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("222aa98d-29f3-4552-bc42-e765c6000eb2"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("22d11d39-7410-4d12-86e1-619e42248dd9"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("23249c74-81c9-47e9-9084-52367ba81319"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("2330e078-a8d7-444f-9647-bffb419f42e3"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("26dcd089-f586-45a4-808f-711896d84723"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("277baf27-7856-4f57-a86c-b0f4e1519017"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("28c4f563-2efe-4f34-8df9-c1baeac32992"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("2a0c7573-f7ae-4ef5-a923-71ac5fa548b6"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("305e9c09-2c90-4bad-ab6b-ae7570ad684b"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("356ea8c4-c50c-479a-9c16-9c06e4dbfcd8"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("365091b8-7e20-4527-8e2d-5363692c8c7f"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("366483ca-2b61-4bb3-9f09-7e94f20e9a83"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("389c99c5-7714-468d-9796-d6bc816b82e4"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("38b07b1f-b7f5-477b-9fd7-893814d03a4c"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("41c51976-8884-488c-a36e-3d799b50832e"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("42ca9979-6a09-4ff1-9f22-c679e7718d80"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("434e2e82-3669-4f50-bbe7-fbc9fe644caf"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("462bd4a5-e94b-42b7-b9b7-e8396061ec7a"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("47741c56-6b1a-44fd-bdd4-ddb7e3d7f724"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("481932a6-504b-4ba0-a14c-606833072299"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("497a7757-66fe-46ec-89ba-9eb2895b9768"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("4a1ee378-e616-49ca-b884-cbc23a3344b0"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("4c2ad544-8336-47e4-82a8-80d36e8cbaa7"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("4eee617c-7f4e-46a0-b783-b1b8073d346c"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("4f560415-c2a9-4c16-a021-b547c28e416b"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("52b7f637-109a-491d-971e-7201f7e2bdb0"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("541e9968-d017-4bf6-a41a-22b667cff92e"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("5669fe67-b55e-4f32-b63e-8d21e528f0fa"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("5adf86fc-dbe1-4b0c-8a05-45b4f14a3238"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("5b2dd237-e0ea-442e-b200-4feec9a91a77"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("5c8566bc-c29d-4001-a190-abb02006e369"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("5fc7e80c-b54d-49f7-92ee-afd863e8ea49"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("6383cbb8-11ef-415b-accd-b0c97d6da9be"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("66046545-0747-4369-a71c-2e284914edbb"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("6a41a0b6-723b-4939-96c6-f2324d7310ef"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("6cecbbc6-f43d-466d-9650-b8d7161cf225"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("6d48a7d5-cc70-48df-8d4e-acae03ad2b62"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("7225b812-857f-4017-9282-95dba1d5affd"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("756df21d-ef11-49ab-b0ce-791905e52dfe"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("78ea6a5a-4708-4904-bf20-53526e9d62da"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("7b686076-f7dd-4f69-97c2-d2149605e0ea"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("802ee8d3-3039-46c1-ac6a-45db7a20e98c"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("82afe9a3-a537-443b-97c2-0eda2f8a6343"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("8664d04c-390f-4c10-bbd8-60867036d06c"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("8acea1d6-7821-4d68-ad0f-50b342a2b877"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("8b3c3780-4b87-4305-90cd-fd6e4e473a27"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("8b6b4413-d674-4af2-9e38-e67e4c0324a3"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("8ff74648-d898-4c4a-a76e-c910368cfc77"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("91351a43-7b88-463c-b4d8-fcb33221ae25"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("91c990ae-4192-4cdd-991d-9e22c90a764b"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("9615dc85-c0be-4c2f-a4b4-ffe5b222298f"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("96dfec93-9b99-43d1-947f-baf7b1221647"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("97d7254e-ffc3-4f0b-931d-5c2a71b77e3d"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("997e36ff-0c39-45c6-b0d7-844dbe61b4f1"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("9adfe3e8-6c62-4a91-9574-4dd8b0c31a85"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("9bca5879-015b-4d68-a0e5-4308d6c084e3"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("9c4acd31-81ca-448e-a43e-69bc86043b5a"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("a2537e9e-4afc-4ec8-8b01-f79373e85810"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("a286a4a7-3332-4741-81a3-8e3fe81c4d40"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("a36c3a13-84d1-456e-a1e5-28e13e7dba05"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("a4ec1179-c366-492c-aa28-1c1271eee35d"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("a61b823e-5663-42a5-936c-aea459564c3b"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("a9efcc1f-1969-46d7-abbe-c1569fef6e6c"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("aabf86ff-a4fb-4c86-8074-e7e313afb3c4"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("b2410fdd-8e5b-4cef-ab61-07ae930b1962"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("b2d3f3db-aad8-41c9-94bd-4ae8775ebfdd"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("b3d02b02-853a-4c8c-84ff-8d330d4d6de9"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("b408faa6-85b8-42e9-8347-bef81c7ff5ee"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("b4d4a790-79fc-42e2-8fc3-cbc886432802"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("b65bcebb-ec23-4c33-962f-ba6b6bb4632e"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("b82c7046-9efb-42be-8892-39d011b53e26"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("b9fe4e04-72f5-4638-a293-869f0eaaad18"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("baaddf2f-bdd8-460e-b581-3ae086b4a92a"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("bc732dad-8593-4652-82c2-5174efa777f8"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("bf0ceb2a-4173-4679-8248-eb5caa521930"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("bf972265-1f03-416b-9f19-3a5163573063"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("c15db080-fedc-456c-91eb-791e92bddd52"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("c18854f0-6152-42f0-8de8-73878c29c89c"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("c372b7c2-4e09-4877-a6d2-8ae995e8df11"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("c532d499-1ee5-45a4-97a7-993f150edbcb"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("c7d5d113-3c84-4386-bc56-ea8677cb372a"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("c95f9540-c170-4c53-829b-9c38b261528f"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("cc4117fd-7818-44d7-99a5-6c53c154d4f8"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("ce7b2acf-ae00-49c5-b40f-f9fb3942f14f"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("d3f9d2c7-a635-4f6b-a57c-da844171fa64"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("d8f36aff-6678-40e5-ac3f-40c3a6ae283d"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("ddba0465-b9a8-408d-b289-f8c95752639b"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("e1d394bb-b450-47de-a788-4f99bc55fa9f"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("e214d688-12ab-42be-9448-235edb15caf5"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("e2ad8d3b-624b-45dc-9b24-228c0a96a982"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("e5cf94d8-6417-459c-8a54-e30ca386fdb6"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("e6bccde8-d5ce-42bc-be0f-2b4580a34400"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("e8e6db43-6d3c-469a-9033-9acd7e42147e"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("f1011667-d18b-44c8-90e2-18e5d85e1be1"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("f1dbf65b-ce4d-4161-bedd-656268546e8a"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("f2ecade4-4a25-419d-91b9-9cff1ce31853"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("f520ae50-b179-4a66-b3b2-f237ed0971f5"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("f7fefa93-c53e-4997-a2bb-2f40ba032a43"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("f94e3f88-b182-4c23-b821-45443ef706b0"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("f9830aec-653c-4bd1-83a6-d1815e1dac82"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("fb60d668-e9fb-4883-9c91-0028bddc066d"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("ff32ab4a-be7c-4c53-959f-9e40ecb019f0"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("ff991007-6d77-4166-9241-47b8f41e4954"));

            migrationBuilder.DropColumn(
                name: "Tags",
                table: "Technologies");
        }
    }
}
