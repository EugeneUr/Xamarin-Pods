# APNumberPad

- If you made changes in the iOS code you will need to follow steps 1 and 3 only.
- If you made changes in the iOS code that exposes more public methods, you will need to follow steps 1-3.
- NOTE: running step 2 will generate new binding files. You will have to fix the error/warning messages yourself, aside from any other addtional changes you are adding to the binding.
- NOTE: you have to copy the images over from iOS to Xamarin if you change them.

1. To build the iOS project simply run "make" inside the iOS folder
2. To generate the c# binding run the following command inside the iOS folder

"sharpie bind -output . -namespace APNumberPads -sdk iphoneos9.0 ./APNumberPad/APNumberPad.h"

3. Refresh the newly generated .a file with the current one inside the Xamarin folder  