
using System.Drawing;


namespace new_ga_e.Entities
{
    public class Entity
    {
        public int posX;
        public int posY;

        public int dirX;
        public int dirY;
        public bool IsMoving;

        public int currentAnimation;
        public int currentLimit;
        public int currentFrame;

        public int flip;

        public int idleFrame;
        public int healFrame;
        public int upFrame;
        public int downFrame;
        public int leftFrame;
        public int rightFrame;


        public int size;

        public Image spriteSheet;

        public Entity(int posX, int posY, int idleFrame, int healFrame, int upFrame, int downFrame,  int leftFrame, int rightFrame, Image spriteSheet)
        { 
            this.posX = posX;
            this.posY = posY;

            this.idleFrame = idleFrame;
            this.healFrame = healFrame;
            this.upFrame = upFrame;
            this.downFrame = downFrame;
            this.leftFrame = leftFrame;
            this.rightFrame = rightFrame;
            this.spriteSheet = spriteSheet;
            currentAnimation = 0;
            currentFrame = 0;
            currentLimit = idleFrame;
            flip = 1;
            size = 30;
        }

        public void Move()
        {
            posX += dirX;
            posY += dirY;

        }

        public void PlayAnimation(Graphics g)
        {
            if (currentFrame < currentLimit - 1)
                currentFrame++;
            else
                currentFrame = 0;
            g.DrawImage(spriteSheet, new Rectangle(new Point(posX,posY), new Size(size, size)),32*currentFrame, 32*currentAnimation, size, size, GraphicsUnit.Pixel);
        }

        public void SetAnimationConfiguration(int currentAnimation)
        {
            this.currentAnimation = currentAnimation;

            switch (currentAnimation)
            {
                case 0:
                    currentLimit = idleFrame;
                    break;
                case 1 :
                    currentLimit = healFrame;
                    break;
                case 2:
                    currentLimit = upFrame;
                    break;
                case 3:
                    currentLimit = downFrame;
                    break;
                case 4:
                    currentLimit = leftFrame;
                    break;
                case 5:
                    currentLimit = rightFrame;
                    break;

            }
        }
    }
}
