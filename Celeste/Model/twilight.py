import spacy, nltk

import fastapi, uvicorn

from transformers import AutoTokenizer
from transformers import AutoModelForSequenceClassification
from scipy.special import softmax

base = f"cardiffnlp/twitter-roberta-base-sentiment"
tokenizer = AutoTokenizer.from_pretrained(base)
model = AutoModelForSequenceClassification.from_pretrained(base)
