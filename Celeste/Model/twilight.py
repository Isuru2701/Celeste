import spacy, nltk

import fastapi, uvicorn

from transformers import AutoTokenizer
from transformers import AutoModelForSequenceClassification
from scipy.special import softmax

base = f"cardiffnlp/twitter-roberta-base-sentiment"
tokenizer = AutoTokenizer.from_pretrained(base)
model = AutoModelForSequenceClassification.from_pretrained(base)

import nltk
from nltk.sentiment import SentimentIntensityAnalyzer

#nltk.download('vader_lexicon')

text = "Today was a weird day, it felt kinda ok cuz my friend Linda spoke to me after so long, but there is also that feeling of something that was normal being broken. I think everyone has a chance to improve, but does she really? after what she did to me? I find it annoying how close she is to me, it feel like she's copying everything I do, and it's frustrating. But I guess I can give her a chance, everything works out when I have chocolate."
sentiment_analyzer = SentimentIntensityAnalyzer()

score = sentiment_analyzer.polarity_scores(text)

print(score)

