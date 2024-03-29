﻿namespace FaceRecognitionDotNet
{

    internal sealed class FaceRecognitionModels
    {

        public static string GetPosePredictorModelLocation()
        {
            return "shape_predictor_68_face_landmarks.dat";
        }

        public static string GetPosePredictorFivePointModelLocation()
        {
            return "shape_predictor_5_face_landmarks.dat";
        }

        public static string GetFaceRecognitionModelLocation()
        {
            return "dlib_face_recognition_resnet_model_v1.dat";
        }

        public static string GetCnnFaceDetectorModelLocation()
        {
            return "mmod_human_face_detector.dat";
        }

    }

}
