using MartinMatta_MerlinCore.Actors.Interfaces;
using MartinMatta_MerlinCore.Commands;
using MartinMatta_MerlinCore.Spells;
using MartinMatta_MerlinCore.Spells.Interfaces;
using Merlin2d.Game;
using Merlin2d.Game.Actions;
using Merlin2d.Game.Actors;

namespace MartinMatta_MerlinCore.Actors
{
    public class Player : AbstractWizardCharacter
    {
        private Animation animation;

        private int intersectCounter;
        private int speedUpCounter;
        private int manaRechargeCounter;

        private NormalSpeedStrategy normalSpeedStrategy;
        private ModifiedSpeedStrategy modifiedSpeedStrategy;
        
        private ICommand moveUp;
        private ICommand moveDown;
        private ICommand moveRight;
        private ICommand moveLeft;

        private ISpellDirector spellDirector;

        public Player(int x, int y, double speed)
        {
            this.SetPosition(x, y);

            this.intersectCounter = 0;
            this.speedUpCounter = 0;
            this.manaRechargeCounter = 0;


            this.spellDirector = new SpellDirector(this);

            this.speed = speed;
            this.normalSpeedStrategy = new NormalSpeedStrategy();
            this.modifiedSpeedStrategy = new ModifiedSpeedStrategy();
            this.strategy = this.normalSpeedStrategy;

            this.animation = new Animation("resources/sprites/player.png", 28, 47);
            this.SetAnimation(animation);
            this.GetAnimation().Start();

            Console.WriteLine("speed");
            Console.WriteLine(this.speed);

            this.moveUp = new Move(this, 0, -1);
            this.moveDown = new Move(this, 0, 1);
            this.moveRight = new Move(this, 1, 0);
            this.moveLeft = new Move(this, -1, 0);
            this.orientation = ActorOrientation.RIGHT;
        }

        public override void Update()
        {
            //Console.WriteLine(this.speed);
            Console.WriteLine(this.GetHealth());
            Console.WriteLine(this.GetMana());
            //Console.WriteLine(this.strategy);
            IActor enemy = this.GetWorld().GetActors().Find(x => x.GetName() == "Spooky Scary Skeleton");
            if(this.GetHealth() > 0)
            {
                manaRechargeCounter++;
                if(manaRechargeCounter == 90)
                {
                    this.ChangeMana(5);
                    this.manaRechargeCounter = 0;
                }
                if (this.strategy is SpeedUpSpeedStrategy)
                {
                    if (this.speedUpCounter == 180)
                    {
                        this.speedUpCounter = 0;
                        this.strategy = this.normalSpeedStrategy;
                    }
                    this.speedUpCounter++;
                }
                if (enemy != null)
                {
                    if (this.IntersectsWithActor(enemy))
                    {
                        //Console.WriteLine("intersects");
                        if (this.intersectCounter == 5)
                        {
                            this.intersectCounter = 0;
                            this.ChangeHealth(-5);
                        }
                        this.intersectCounter++;
                        this.strategy = this.modifiedSpeedStrategy;
                    }
                    else
                    {
                        this.strategy = this.normalSpeedStrategy;
                    }
                }
                if (Input.GetInstance().IsKeyDown(Input.Key.UP))
                {
                    animation.Start();
                    this.moveUp.Execute();
                }
                else if (Input.GetInstance().IsKeyDown(Input.Key.DOWN))
                {
                    animation.Start();
                    this.moveDown.Execute();
                }
                else if (Input.GetInstance().IsKeyDown(Input.Key.RIGHT))
                {
                    if (this.orientation == ActorOrientation.LEFT)
                        animation.FlipAnimation();
                    animation.Start();
                    this.moveRight.Execute();
                    this.orientation = ActorOrientation.RIGHT;
                }
                else if (Input.GetInstance().IsKeyDown(Input.Key.LEFT))
                {
                    if (this.orientation == ActorOrientation.RIGHT)
                        animation.FlipAnimation();
                    animation.Start();
                    this.moveLeft.Execute();
                    this.orientation = ActorOrientation.LEFT;
                }
                else
                {
                    animation.Stop();
                }

                if (Input.GetInstance().IsKeyPressed(Input.Key.Q))
                {
                    ISpell spell = this.spellDirector.Build("Into the Fray!");
                    spell.ApplyEffects(this);
                }
                else if (Input.GetInstance().IsKeyPressed(Input.Key.E))
                {
                    this.spellDirector.Build("icicle");
                }
            }
            else
            {
                this.Die();
            } 
        }
    }
}
