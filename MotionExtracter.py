import cv2
from PoseDetectionModule import poseDetector
import mediapipe as mp

width, height = 1280, 720
filename = "CoordinateFile"

cap = cv2.VideoCapture("Test/test12.mp4")

cap.set(3, width)
cap.set(4, height)

detector = poseDetector()

positionsList = []

while True:
    success, img = cap.read()

    if (success):

        img = detector.findPose(img)
        lmlist = detector.spotLandmarks(img, draw=False)

        if len(lmlist) != 0:
            lmString = ''

            for lm in lmlist:
                lmString += f'{lm[1]}, {height-lm[2]}, {lm[3]},'
            
            positionsList.append(lmString)
        
        cv2.imshow("Image", img)

        key = cv2.waitKey(10)

        if key == ord("s"):
            with open(f'{filename}.txt', "w") as f:
                for i in positionsList:
                    f.write(i + '\n')

        if key & 0xFF == ord("q"):
            break

    else:
        with open(f'{filename}.txt', "w") as f:
                for i in positionsList:
                    f.write(i + '\n')
        break

cap.release()
cv2.destroyAllWindows()