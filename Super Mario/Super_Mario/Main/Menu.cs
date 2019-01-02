using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Super_Mario
{
    class Menu
    {
        Texture2D texture;
        Vector2 position;
        Rectangle rectangle;

        Color color = new Color(255, 255, 255, 255);

        public Vector2 size;
        public Menu(Texture2D newtexture, GraphicsDevice graphics)
        {
            texture = newtexture;
            size = new Vector2(graphics.Viewport.Width / 7, graphics.Viewport.Height / 7);

        }
        bool down;
        public bool IsClicked;
        public void Update(MouseState mouse)
        {
            rectangle = new Rectangle((int)position.X, (int)position.Y, (int)size.X, (int)size.Y);
            Rectangle mouserectangle = new Rectangle(mouse.X, mouse.Y, 1, 1);
            if (mouserectangle.Intersects(rectangle))
            {
                if (color.A == 255) down = false;
                if (color.A == 0) down = true;
                if (down) color.A += 3;
                else color.A -= 3;
                if (mouse.LeftButton == ButtonState.Pressed)
                {
                    IsClicked = true;
                }

            }
            else if (color.A < 225)
            {
                color.A += 3;
                IsClicked = false;
            }
        }
        public void SetPosition(Vector2 newposition)
        {
            position = newposition;
        }
        public void Draw(SpriteBatch spritebatch)
        {

            spritebatch.Draw(texture, rectangle, color);
        }

    }
}
