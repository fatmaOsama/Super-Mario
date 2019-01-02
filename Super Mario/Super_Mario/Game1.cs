using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace Super_Mario
{
    


    public class Game1 : Microsoft.Xna.Framework.Game
    {

        //This is the Game World 


        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        Texture2D BackgroundTexture1;
        Rectangle BackgroundRectangle1;

        SpriteFont Font;

        Kingdom kingdom;
        int[,] level;

        Camera camera;

        enum GameState
        {
            MainMenu,
            GameOn,
            GameOver
        }
        GameState CurrentState = GameState.MainMenu;
        int ScreenW = 800, ScreenH = 600;
    

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        public int[,] GenerateArray()
        {
            Random random = new Random();
            int sizeX = 12, sizeY = 20*15, JumpHeight = 2, MaxHeight = 3;
            int[,] arr = new int[sizeX, sizeY];
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    arr[i, j] = 0;
                }
            }

           //Generate Floor
           Vector2 CurrentPosition = new Vector2(sizeX - 1, 0);
            arr[(int)CurrentPosition.X, (int)CurrentPosition.Y] = 1;

            while (CurrentPosition.Y != sizeY - 1)
            {
                int Direction = random.Next(2, 5);

                switch (Direction)
                {
                    case 1: //left
                        if (CurrentPosition.Y - 1 >= 0 && arr[(int)CurrentPosition.X, (int)CurrentPosition.Y - 1] != 1)
                        {
                            CurrentPosition.Y--;
                            arr[(int)CurrentPosition.X, (int)CurrentPosition.Y] = 1;
                           
                        }
                        break;
                    case 2: //down 
                        if (CurrentPosition.X + 1 <= sizeX - 1 && arr[(int)CurrentPosition.X + 1, (int)CurrentPosition.Y] != 1)
                        {
                            CurrentPosition.X++;
                            arr[(int)CurrentPosition.X, (int)CurrentPosition.Y] = 1;
                            
                        }
                        break;
                    case 3: //right
                        if (CurrentPosition.Y + 1 <= sizeY - 1 && arr[(int)CurrentPosition.X, (int)CurrentPosition.Y + 1] != 1)
                        {
                            CurrentPosition.Y++;
                            arr[(int)CurrentPosition.X, (int)CurrentPosition.Y] = 1;
                           
                        }
                        break;
                    case 4: //up
                        if (CurrentPosition.X - 1 >= 0 && arr[(int)CurrentPosition.X - 1, (int)CurrentPosition.Y] != 1 && CurrentPosition.X - 1 >= sizeX - MaxHeight)
                        {
                            int i = (int)CurrentPosition.X - 1, j = (int)CurrentPosition.Y - 1;
                            if (j < 0) continue;
                            while (arr[i, j] != 1)
                            {
                                i++;
                                if (i >= sizeX - 1)
                                    break;
                            }
                            if (i - CurrentPosition.X - 1 < 1)
                            {
                                CurrentPosition.X--;
                                arr[(int)CurrentPosition.X, (int)CurrentPosition.Y] = 1;
                               
                            }
                        }
                        break;
                }

            }
            //Fill Floor
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    if (arr[i, j] == 1)
                    {
                        if (i + 1 <= sizeX - 1)
                        {
                            arr[i + 1, j] = 1;
                        }
                    }
                }
            }

            //Generate Bricks
            int BricksNumber = sizeY / 6, BricksCount = 0;
            int NormalBricksNumber = BricksNumber / 2, NormalBricksCount = 0;
            int SpecialBricksNumber = BricksNumber / 4, SpecialBricksCount = 0;
            int SecretBricksNumber = BricksNumber / 2, SecretBricksCount = 0;

            while (BricksCount < BricksNumber)
            {
                int row = random.Next(6, sizeX);
                int col = random.Next(1, sizeY);
                if (row <= sizeX - 1 && row >= 0 && col <= sizeY && col >= 0) //Array Constrains 
                {
                    if (arr[row, col] != 1 && arr[row, col] != 2)
                    {
                        int i = row + 1, j = col;

                        if (i >= sizeX) continue;
                        while (arr[i, j] != 1)
                        {
                            i++;
                            if (i >= sizeX - 2)
                                break;
                        }
                        if (i - row == JumpHeight + 2)
                        {
                            int SideBySide = 0;
                            while (SideBySide < 3)
                            {
                                int BrickType = random.Next(3, 6);
                                if (BrickType == 3 && NormalBricksCount < NormalBricksNumber)
                                {

                                    arr[row, col] = BrickType;
                                    NormalBricksCount++;
                                    BricksCount++;
                                }
                                else if (BrickType == 4 && SpecialBricksCount < SpecialBricksNumber)
                                {
                                    if (j - 1 >= 0 && j + 1 < sizeY - 1 && (arr[i, j - 1] == 4 || arr[i, j + 1] == 4) )
                                        continue;
                                    arr[row, col] = BrickType;
                                    SpecialBricksCount++;
                                    BricksCount++;
                                }
                                else if (BrickType == 5 && SecretBricksCount < SecretBricksNumber)
                                {

                                    if (j - 1 >= 0 && j + 1 < sizeY - 1 && (arr[i, j - 1] == 5 || arr[i, j + 1] == 5))
                                        continue;
                                    arr[row, col] = BrickType;
                                    SecretBricksCount++;
                                    BricksCount++;
                                }
                                if (col >= sizeY - 1) break;
                                col++;
                                SideBySide++;
                            }
                        }
                    }
                }

            }
            //Genrate enemies 
            int EnemiesMaxNum = sizeY / 20, EnemiesCount = 0;
            while (EnemiesCount < EnemiesMaxNum)
            {
                 int row = random.Next(1, sizeX);
                int col = random.Next(1, sizeY);
                if (row <= sizeX - 1 && row >= 0 && col <= sizeY && col >= 0) //Array Constrains 
                {
                    if (arr[row, col] ==0  && row+1 <sizeX-1 &&
                       ( arr[row+1, col] == 1 || arr[row+1, col] == 3 || arr[row+1, col] == 4 || arr[row+1, col] == 5))
                    {
                        int EnemyType = random.Next(6, 11);
                        arr[row, col] = EnemyType;
                        EnemiesCount++;
                    }
                
                }
            }
            //Generate Gifts;
            int GiftMaxNum = sizeY / 30, GiftCount = 0;
            while (GiftCount < GiftMaxNum)
            {
                int row = random.Next(1, sizeX);
                int col = random.Next(1, sizeY);
                if (row <= sizeX - 1 && row >= 0 && col <= sizeY && col >= 0) //Array Constrains 
                {
                    if (arr[row, col] == 0)
                    {
                        int i = row + 1, j = col;

                        if (i >= sizeX) continue;
                        while (true)
                        {
                            if (arr[i, j] == 1 || arr[i, j] == 3 || arr[i, j] == 4 || arr[i, j] == 5) break;
                            i++;
                            if (i >= sizeX - 2)
                                break;
                        }
                        if (i - row <= JumpHeight)
                        {
                            int GiftType = random.Next(11, 15);
                            arr[row, col] = GiftType;
                            GiftCount++;
                        }

                    }
                }
            }
            
            //Genrate Coins
            int CoinkMaxNum = sizeY/2, CoinCount = 0;
            while (CoinCount < CoinkMaxNum)
            {
                int row = random.Next(1, sizeX);
                int col = random.Next(1, sizeY);
                if (row <= sizeX - 1 && row >= 0 && col <= sizeY && col >= 0) //Array Constrains 
                {
                    if (arr[row, col] ==0)
                    {
                        int i = row + 1, j = col;

                        if (i >= sizeX) continue;
                        while (true)
                        {
                            if (arr[i, j] == 1 || arr[i, j] == 3 || arr[i, j] == 4 || arr[i, j] == 5) break;
                            i++;
                            if (i >= sizeX - 2)
                                break;
                        }
                        if (i - row <= JumpHeight)
                        {
                            arr[row, col] = 2;
                            CoinCount++;
                        }

                    }
                }
            }


            return arr;
        }
      
        protected override void Initialize()
        {
            kingdom = new Kingdom();
            camera = new Camera(GraphicsDevice.Viewport);
            level=GenerateArray();
            for (int i = 0; i < level.GetLength(0); i++)
            {
                for (int j = 0; j < level.GetLength(1); j++)
                {


                    Console.Write(level[i, j]);
                }
                Console.WriteLine("");
            }
            kingdom.GenerateLevel(level);
            base.Initialize();
        }

        protected override void LoadContent()
        {
            Song song = Content.Load<Song>("Super Mario Bros Theme Song");
            MediaPlayer.Play(song);

            spriteBatch = new SpriteBatch(GraphicsDevice);
            BackgroundTexture1 = Content.Load<Texture2D>("Background");
            BackgroundRectangle1 = new Rectangle(0, 0, 800, 500);

            Font = Content.Load<SpriteFont>("Sfont");



            Kingdom.Content = Content;
            kingdom.Load();
        
        }

        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }
        
        protected override void Update(GameTime gameTime)
        {

            // Allows the game to exit on pressing escape or red X
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed ||
                Keyboard.GetState().IsKeyDown(Keys.Escape))
                this.Exit();
            kingdom.Update(gameTime);
            camera.Update(gameTime, kingdom.Mario);
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, null, null, null, null, camera.transform);
          
           // spriteBatch.Draw(BackgroundTexture1, BackgroundRectangle1, Color.White);
            spriteBatch.Draw(Content.Load<Texture2D>("COIN"), new Rectangle(kingdom.Mario.rectangle.X - 30, 10, 20, 20), Color.White);
            spriteBatch.DrawString(Font, "X"+ kingdom.CoinsNumber, new Vector2(kingdom.Mario.rectangle.X -10, 10), Color.White);
            spriteBatch.DrawString(Font, "Points: " + kingdom.Points, new Vector2(kingdom.Mario.rectangle.X+100 ,10), Color.White);
            spriteBatch.DrawString(Font, "Time: " + (int)kingdom.Time, new Vector2(kingdom.Mario.rectangle.X +420, 10), Color.White);
            spriteBatch.Draw(Content.Load<Texture2D>("unnamed"), new Rectangle(kingdom.Mario.rectangle.X +300, 10, 20, 20), Color.White);
            spriteBatch.DrawString(Font, "X" + (int)kingdom.Lifes, new Vector2(kingdom.Mario.rectangle.X +320, 10), Color.White);
            kingdom.Draw(spriteBatch);
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
