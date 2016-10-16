Canvas: 
1. Media player time switch progress bar upside
2. MediaPlayerScript: Where you find Player logic "MediaPLayer.cs"
3. Static instance of HUD is in Hierarchy Canvas/HUD (Hud)
4. ScrollRect is in Canvas/HUD/EscMenu/Background/Mask.
5. All Animations are with BetweenUI Transitions. All script is in Project"Assets/Plugins/BetweenUI/Scripts".
6. BetweenUI have 2 scenes demo for best understand.
7. All Transitions operate from Hud instance.
8. All transitions Canvas/HUD/MediaPlayerSwitch (Alpha)
				   Canvas/HUD/MediaPlayerSwitch/Slider (Position)
				   Canvas/HUD/MediaPlayerScript (Position)
				   Canvas/HUD/MediaPlayer/Next (Scale)
10. Controls:
	Pad is Image in Controls/MobileJoystick with script Joystick
	Kick,Hide,Jump is button with method related with Moving Korey script.
11. Health is 3 images related with HUD menu Script.
12. "TryAgain" & "Finish" panels are deactivated siblings with HUD and related with Hud instance.

ADITIONAL WORK for champions and lecturers:
Need to implement propper update on progress slider for the song time.
Need to add logic when the song finished to play next.