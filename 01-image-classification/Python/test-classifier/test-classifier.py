from azure.cognitiveservices.vision.customvision.prediction import CustomVisionPredictionClient
from msrest.authentication import ApiKeyCredentials
import matplotlib.pyplot as plt
from PIL import Image
import os

def classify_image(image_file):

    # Create an instance of the prediction service
    project_id = '9879cc9e-81d3-4d1d-90a1-c9dbd80e6bf5'
    cv_key = 'e2e46cbbc27c48a28d69005afd6b144b'
    cv_endpoint = 'https://gmalccustvision-prediction.cognitiveservices.azure.com/'
    model_name = 'groceries'
    credentials = ApiKeyCredentials(in_headers={"Prediction-key": cv_key})
    custom_vision_client = CustomVisionPredictionClient(endpoint=cv_endpoint, credentials=credentials)

    # Get image classification
    image_contents = open(image_file, "rb")
    classification = custom_vision_client.classify_image(project_id, model_name, image_contents.read())
    prediction = classification.predictions[0].tag_name
    print(prediction)

def main():
    image_path = './fruit.jpg'
    classify_image(image_path)

if __name__ == "__main__":
    main()

