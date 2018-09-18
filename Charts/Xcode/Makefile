XBUILD=/Applications/Xcode.app/Contents/Developer/usr/bin/xcodebuild
PROJECT_ROOT=.
PROJECT=$(PROJECT_ROOT)/Charts.xcodeproj
TARGET=Charts

all:	lib$(TARGET).a

lib$(TARGET)-default.a:
	$(XBUILD) -project $(PROJECT) -target $(TARGET) -sdk macosx10.13 -configuration Release clean build
	-cp $(PROJECT_ROOT)/build/Release/Charts.framework/Versions/A/$(TARGET) $@

lib$(TARGET)-x86_64.a:
	$(XBUILD) -project $(PROJECT) -target $(TARGET) -sdk macosx10.13 -arch x86_64 -configuration Release clean build
	-cp $(PROJECT_ROOT)/build/Release/Charts.framework/Versions/A/$(TARGET) $@

lib$(TARGET).a:		lib$(TARGET)-x86_64.a
	xcrun -sdk macosx10.13 lipo -create -output $@ $^

clean:
	-rm -f *.a *.dll
