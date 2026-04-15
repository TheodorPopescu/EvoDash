**EvoDash** is a fast-paced 2D platformer built with Unity where agility and timing are everything. Navigate through challenging obstacle courses using precise jumps and rapid dashes to reach the finish line in record time. 

🎮 **[Play the game directly in your browser here!](https://theodorpopescu.github.io/EvoDash/)**

*(Optional: Insert a GIF or Screenshot of your gameplay here)*
<!-- ![Gameplay Screenshot](link_to_image_here) -->

## ✨ Features

* **Fluid Movement Mechanics**: Master the art of jumping and dashing to maneuver through tight spaces and avoid hazards.
* **Challenging Obstacle Courses**: Test your reflexes and timing as you race to the finish line.
* **Global Leaderboard**: Built with a **MongoDB cloud database**, allowing you to save your best times and compete globally against other players.
* **Web-Ready**: Exported using WebGL, making it easily accessible for anyone to play without needing to download any files.

## 🕹️ Controls

* **A / D** or **Left / Right Arrows** - Move
* **Space** - Jump
* **Space while in the air** - Dash


## 🛠️ Tech Stack

* **Game Engine**: Unity (C#)
* **Database**: MongoDB (Cloud)
* **Deployment**: GitHub Pages (WebGL)

## 🧠 Technical Implementation

To build a smooth, web-ready platformer with a real-time leaderboard, I focused on clean architecture and optimized performance:

* **Player Controller (State Machine):** Implemented a custom state-driven player controller to handle transitions between running, jumping, dashing, and falling. This decoupled the input logic from the physics execution, making the movement feel tight and responsive.
* **Database Integration:** Integrated MongoDB to handle the global leaderboard. *(Explain how you did it here. E.g., Did you build a custom REST API using Node.js/Express? Did you use UnityWebRequest? Mentioning how you handled CORS issues for WebGL or secured the database connection is a huge plus!)*
* **Physics & Collision:** Utilized Unity's Rigidbody2D and optimized Raycasting for ground detection to prevent the "wall-sticking" bugs common in 2D platformers.
* **WebGL Optimization:** Optimized texture compressions and stripped unused Unity engine code to ensure the WebGL build loads quickly in the browser.
