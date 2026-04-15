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

* **Custom REST API**: Built a backend middleware using Node.js and Express. This server handles all routing and communicates with a MongoDB database via Mongoose. It includes endpoints for checking player name availabilitt, submitting new completion times, and fetching the top 10 fastest times.
Secure Database Connection: By routing database requests through a dedicated backend API, the MongoDB connection string (MONGO_URI) is safely hidden in server-side environment variables. This prevents malicious users from decompiling the Unity client and stealing database credentials.
Unity Client Communication: On the frontend, the game uses UnityWebRequest to serialize player data into JSON format and asynchronously send POST/GET requests to the server without freezing the gameplay.
* **WebGL Compatibility & CORS:** To ensure the leaderboard works perfectly in a browser environment (Unity WebGL), I implemented the cors middleware in the Express server. This resolves Cross-Origin Resource Sharing (CORS) security blocks, allowing the hosted game to safely fetch and post data to the API.
* **Physics & Collision:** Utilized Unity's Rigidbody2D and optimized Raycasting for ground detection to prevent the "wall-sticking" bugs common in 2D platformers.

