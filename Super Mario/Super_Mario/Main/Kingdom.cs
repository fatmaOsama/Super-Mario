using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Super_Mario
{
    class Kingdom
    {
        

        Mario mario;
        List<Bullets> bullets;
        KeyboardState akherKey;
        Vector2 PrevPosition;
        bool AkherKey;


        List<Bricks> bricks;
        List<Coins> coins;
        List<StaticEnemies> staticEnemies;
        List<DynamicEnemies> dynamicEnemies;
        List<Gifts> gifts;

        public int CoinsNumber, Points,Lifes;
        public float Time;


        private static ContentManager content;
        public static ContentManager Content
        {
            set { content = value; }
            get { return content; }
        }

        public Mario Mario
        {
            set { mario = value; }
            get { return mario; }
        }

        public Kingdom()
        {
            CoinsNumber = Points = 0;
            Time = 0;
            Lifes = 3;
            mario = new Mario();
            bullets = new List<Bullets>();
            bricks = new List<Bricks>();
            coins = new List<Coins>();
            staticEnemies = new List<StaticEnemies>();
            dynamicEnemies = new List<DynamicEnemies>();
            gifts = new List<Gifts>();
            
        }

        public void GenerateLevel(int[,] array)
        {
            for (int i = 0; i < array.GetLength(1); i++)
            {
                for (int j = 0; j < array.GetLength(0); j++)
                {
                    int type = array[j, i];
                    if (type == 1 || type==3)
                    {
                        bricks.Add(new NormalBricks(new Vector2(i *Bricks.Size , j * Bricks.Size)));
                        
                    }
                    else if (type == 2)
                    {
                        coins.Add(new Coins(new Vector2(i *40 , j * 40)));
                    }
                    else if (type == 4)
                    {
                        bricks.Add(new SpecialBricks(new Vector2(i * 40, j * 40)));
                    }
                    else if (type == 5)
                    {
                        bricks.Add(new SecretBricks(new Vector2(i * 40, j * 40)));
                    }
                    else if (type == 6)
                    {
                        dynamicEnemies.Add(new Goomba(new Vector2(i * 40, j * 43)));
                    }
                    else if (type == 7)
                    {
                        dynamicEnemies.Add(new KoopaTroopa(new Vector2(i * 40, j * 43)));
                    }
                    else if (type == 8)
                    {
                        dynamicEnemies.Add(new PiranhaPlant(new Vector2(i * 40, j * 40)));
                    }
                    else if (type == 9)
                    {
                        staticEnemies.Add(new Spiny(new Vector2(i * 40, j * 40)));
                    }
                    else if (type == 11)
                    {
                        gifts.Add(new FireFlower(new Vector2(i * 40, j * 40)));
                    }
                    else if (type == 12)
                    {
                        gifts.Add(new SuperStar(new Vector2(i * 40, j * 40)));
                    }
                    else if (type == 13)
                    {
                        gifts.Add(new UpMushrom(new Vector2(i * 40, j * 40)));
                    }
                    else if (type == 14)
                    {
                        gifts.Add(new SuperMushrom(new Vector2(i * 40, j * 40)));
                    }
                }
            }
        }

        public void Load()
        {
            Coins.Content = Content;
            Mario.Content = Content;
            Bricks.Content = Content;
            Bullets.Content = Content;
            Goomba.Content = Content;
            KoopaTroopa.Content = Content;
            PiranhaPlant.Content = Content;
            Spiny.Content = Content;
            Bill_Blaster.Content = Content;

            foreach (Bullets bullet in bullets)
            {
                bullet.Load();
            }

            mario.Load();

            foreach (Bricks brick in bricks)
            {
                brick.Load();
            }

            foreach (DynamicEnemies enemy in dynamicEnemies)
            {
                enemy.Load();
            }

            foreach (StaticEnemies enemy in staticEnemies)
            {
                enemy.Load();
            }

            foreach (Gifts gift in gifts)
            {
                gift.Load();
            }

            foreach (Coins coin in coins)
            {
                coin.Load();
            }
        }

        public void Update(GameTime gameTime)
        {
            PrevPosition = mario.Position;
            CoinsNumber = Coins.CoinsNumber;

            Time += (float)gameTime.ElapsedGameTime.TotalSeconds;
            foreach (Gifts gift in gifts)
            {
               
                if (gift.Action(mario.rectangle))
                {
                    Points += gift.points;
                    if (gift.Type == 1)
                    {
                        //FireFlower
                        mario = new FireMario(mario.Position, mario.rectangle);
                        mario.Load();
                    }
                    else if (gift.Type == 2)
                    {
                        //SuperStar
                        mario = new SuperMario(mario.Position, mario.rectangle);
                        mario.Load();
                    }
                    else if (gift.Type == 3)
                    {
                        //UpMushroom
                        Lifes++;
                    }
                    else if (gift.Type == 4)
                    {
                        //SuperMushroom
                        mario = new InvincibleMario(mario.Position,mario.rectangle);
                        mario.Load();
                    }
                }
            }
            foreach (Coins coin in coins)
            {
               if( coin.Action(mario.rectangle))
                Points += coin.points;
            }

     
            mario.Update(gameTime);
            MarioInteractions(gameTime);
              foreach (DynamicEnemies enemy in dynamicEnemies)
            {
                enemy.Update(gameTime);
                int action=enemy.Collide(mario.rectangle);
                if (action == -1)
                {
                    Lifes--;
                }
            }
              foreach (StaticEnemies enemy in staticEnemies)
              {
                 
                  int action = enemy.Collide(mario.rectangle);
                  if (action == -1)
                  {
                      Lifes--;
                  }
              }
    
        }
        public void MarioInteractions(GameTime gameTime)
        {

         

            if (Keyboard.GetState().IsKeyDown(Keys.Right))
            {
                // bool flag = false;
                mario.AnimateRight(gameTime);
                mario.Position.X += 1f;

                foreach (Bricks brick in bricks)
                {
                    if (brick.rectangle.RIGHT(mario.rectangle))
                    {
                        mario.Position = PrevPosition;
                        break;
                    }
                }
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Left))
            {
                // bool flag = false;
                mario.AnimateLeft(gameTime);
                mario.Position.X -= 1f;

                foreach (Bricks brick in bricks)
                {
                    if (brick.rectangle.LEFT(mario.rectangle))
                    {
                        mario.Position = PrevPosition;
                        break;
                    }
                }


            }

            if (Keyboard.GetState().IsKeyDown(Keys.Space) && mario.YalaTani)
            {
                mario.Jump = true;
                mario.YalaTani = false;
            }
            if (mario.JumpHeight == 0f)
            {
                mario.JumpHeight = -14f;   //-x
                mario.Jump = false;
                mario.fall = true;

            }
            if (mario.Jump)
            {
                mario.JumpHeight += 1f;
                mario.Position.Y += mario.JumpHeight;
                // x += 0.25f;

            }
            if (mario.fall)
            {
                bool flag = false;
                foreach (Bricks brick in bricks)
                {
                    if (brick.rectangle.TOP(mario.rectangle))
                    {
                        mario.fall = false;
                        mario.YalaTani = true;
                        flag = true;
                    }
                }
                if (!flag)
                {
                    mario.Position.Y += 3f;
                    //  velocity.Y = 0.1f;
                }

            }
            if (Keyboard.GetState().IsKeyDown(Keys.Down))
            {
                PrevPosition = mario.Position;
                mario.Position.Y += 3f;
                foreach(Bricks brick in bricks)
                {
                    if(brick.rectangle.TOP(mario.rectangle))
                    {
                        mario.Position=PrevPosition;
                    }
                }
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Left))
            {
                AkherKey = false;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Right))
            {
                AkherKey = true;
            }

            if (Keyboard.GetState().IsKeyDown(Keys.Enter) && akherKey.IsKeyUp(Keys.Enter) && mario.type == 3)
            {
                Shoot();
            }
            akherKey = Keyboard.GetState();
            UpdateBullets();

        }
        public void UpdateBullets()
        {
            foreach (Bullets bullet in bullets)
            {
                bullet.Position += bullet.Velocity;
                if (Vector2.Distance(bullet.Position, mario.Position) > 300)   //emta yekhtifi nour
                {
                    bullet.IsVisible = false;
                }
            }
            for (int i = 0; i < bullets.Count; i++)
            {
                if (!bullets[i].IsVisible)
                {
                    bullets.RemoveAt(i);
                    i--;
                }
            }
        }

        public void Shoot()
        {
            Bullets newBullet = new Bullets(mario.Position);
            if (mario.Velocity.X < 0 ||mario.Velocity.X == 0 && !AkherKey)
            {
                newBullet.Velocity.X = -3f;

            }
            else if (mario.Velocity.X > 0 || mario.Velocity.X == 0 && AkherKey)
            {
                newBullet.Velocity.X = 3f;
            }
            newBullet.Position = mario.Position + newBullet.Velocity * 5;
            newBullet.IsVisible = true;
            if (bullets.Count < 20)
            {
                newBullet.Load();
                bullets.Add(newBullet);
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
           
        
            foreach (Bricks brick in bricks)
            {
                brick.Draw(spriteBatch);
            }
            foreach (DynamicEnemies enemy in dynamicEnemies)
            {
                if(!enemy.iskilled)
                enemy.Draw(spriteBatch);
            }
            foreach (StaticEnemies enemy in staticEnemies)
            {
                foreach(Bricks brick in bricks)
                {
                    if(enemy.rectangle.Intersects(brick.rectangle))
                    {
                        enemy.Draw(spriteBatch);
                    }
                }
                
            }
            foreach (Gifts gift in gifts)
            {
                if (!gift.IsGained)
                    gift.Draw(spriteBatch);
            }
            foreach (Coins coin in coins)
            {
                if (!coin.IsGained)
                coin.Draw(spriteBatch);
            }
           
            
            mario.Draw(spriteBatch);
            foreach (Bullets bullet in bullets)
            {
                bullet.Draw(spriteBatch);
            }
        }
    }
}



