===============================================================================
							     After
							Transient Games
===============================================================================


===============================================================================
                                   Sections
===============================================================================
About
The Team
The Game
Story
Mechanics
Git


===============================================================================
                                    About
===============================================================================
This is the README file that covers basic details about the After project
and Git usage.


===============================================================================
                                  The  Team
===============================================================================
Transient Games is a coallition of 5 students at the University of Texas at
Austin, whose members are listed below (alphabetically):
	John Dobsom 		Artist director
	Rob Luckfield 		Sound Engineer
	Tyler Pixley 		Programmer
	Matt Schwartz 		Programmer
	Taylor Womack 		Animator and SCRUM master


===============================================================================
                                  The  Game
===============================================================================
	After is a 2D game in production, written in Unity, for the Game 
	Development program at the University of Texas at Austin.


===============================================================================
                                    Story
===============================================================================
	The game takes place in a post-apocalyptic world in which all life is 
	presumed extinct. The unnamed protagonist, controlled by the player, takes
	it upon himself to cure the corruption of the world, caused by the 
	apocalyptic event. When the world was decimated, the sadness of every
	human being coalesced into the hero, which gave him the power to see the 
	souls of the wronged and use them to purify the corruption. Our first level
	is set in a dilapidated city. 

	When the Traveler completes his task, he waits for life to return, though
	he does not know that it ever will.


===============================================================================
                                  Mechanics
===============================================================================
	The game is a puzzle platformer, focused on telling a beautifully tragic 
	story about the revivification of a corrupted and saddened world. The 
	puzzles will be designed to tell this story through the environment and the
	tragic deaths of the wronged souls in the world that the Traveler uses. A
	puzzle cannot be completed by the Traveler alone; he must help the souls to
	help him progress in the world. The player is rewarded with a 
	beautification of the environment and a fantastic animation of freeing the 
	soul.


===============================================================================
                                     Git
===============================================================================
	Git is a version control software that allows any number of people to 
	easily manage a project through a series of snapshots.


===============================================================================
                                 Git Workflow
===============================================================================
	The Git GUI (Graphical User Interface )is a very powerful tool that works
	great - when it works. It is important to understand the underlying 
	workflow to properly use the Git GUI with as little trouble as possible.

	Firstly, it is important to always Sync before you start working on 
	anything. This will prevent unwanted and potentially messy manual merges 
	between files you edited and didn't know others edited.

	Secondly, Commit & Sync whenever you complete a task. If you cannot sum up 
	what you did in a single sentence, then you are not Syncing often enough. 
	This will help keep those manual merges small if/when they occur. 


===============================================================================
                               Git  Terminology
===============================================================================
	It is important to understand what's going on when you are looking at the 
	Git GUI and what these terms mean.

	Commit - When you make changes to a Git repository, you commit these 
	changes along with a brief summary of what you changed. This effectively 
	says to Git "I want these changes to be saved to the repository." This is 
	more of a soft, local save and these changes are not reflected in GitHub's 
	remote copy.

	Pull (terminal) - This command is available as a terminal command. This 
	causes Git to download the remote repository to your local repository. When
	you pull, Git automatically tries to merge files that were changed locally 
	and remotely. If you commit often enough, this usually happens without any 
	manual intervention.

	Push (terminal) - This command is available as a terminal command. This 
	causes Git to upload the local repository to the remote repository. Again, 
	Git automatically tries to merge the two and often does not require any 
	intervention.

	Sync - The Git GUI combines the Pull and Push commands into one. If there 
	are any merge conflicts (requires manual intervention), this functionality 
	tends to fail and doesn't give you much option to solving it. When this 
	happens, it's difficult or impossible to solve without diving into the 
	terminal.

	Branch - Git repositories can be branched from another branch which creates
	a sort of sub-repository that can be modified without affecting other 
	branches. These are very useful when you want to test a feature out without
	altering the main branch (typically the 'master' branch).

	Merge - This applies to merging source files as well as merging branches. 
	For much of the time, Git is able to merge files together without conflict,
	which means you never have to dive into the files and figure out which 
	lines you want reflected in the remote repository.
