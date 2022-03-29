import sys
import pandas as pd
import re

def classify(message):
    message = re.sub('\W', ' ', message)
    message = message.lower().split()
    p_spam_given_message = p_spam
    p_ham_given_message = p_ham

    for word in message:
        if word in dictionary_probab_spam:
            p_spam_given_message *= dictionary_probab_spam[word]
        if word in dictionary_probab_ham:
            p_ham_given_message *= dictionary_probab_ham[word]

    if p_ham_given_message > p_spam_given_message:
        return 'ham'
    else:
        return 'spam'

def main():
    # TEXTMSG spam collection dataset - https://archive.ics.uci.edu/ml/datasets/sms+spam+collection
    dfspam = pd.read_csv('Data Mining\Data Sets\SMSSpamCollection.txt', sep='\t',
    header=None, names=['Label', 'TEXTMSG'])

    print(dfspam.shape)
    print(dfspam.head())
    datastats = dfspam['Label'].value_counts(normalize=True) # 87% spam, 13% ham
    print(datastats)
    # prepare train, test data
    dfrandom = dfspam.sample(frac=1, random_state=50) # randomize data
    split_index = round(len(dfrandom) * 0.8)
    # Split into training and test sets
    train_set = dfrandom[:split_index].reset_index(drop=True)
    test_set = dfrandom[split_index:].reset_index(drop=True)
    print(train_set.shape)
    print(test_set.shape)
    # print spam/ham statistics of the train and test sets
    train_stats = train_set['Label'].value_counts(normalize=True)
    print(train_stats)
    test_stats = test_set['Label'].value_counts(normalize=True)
    print(test_stats)
    print(train_set.head(10))
    print('----after removing punctuation and converting to lower case-----')
    # remove punctuation------------
    train_set['TEXTMSG'] = train_set['TEXTMSG'].str.replace('\W', ' ')
    train_set['TEXTMSG'] = train_set['TEXTMSG'].str.lower()
    print(train_set.head(10))
    # create vocabulary of unique words from the train set
    train_set['TEXTMSG'] = train_set['TEXTMSG'].str.split()

    vocab = []
    for msg in train_set['TEXTMSG']: # TEXTMSG column
        for word in msg:
            vocab.append(word)
    vocab = list(set(vocab)) # unique words, set removes the duplicates
    print(len(vocab))

    # separate spam and ham messages
    spam_train_set = train_set[train_set['Label'] == 'spam']
    ham_train_set = train_set[train_set['Label'] == 'ham']

    dictionary_word_counts_spam = {word: 0 for word in vocab} # initialize count to 0
    for index, msg in enumerate(spam_train_set['TEXTMSG']):
        for word in msg:
            dictionary_word_counts_spam[word] += 1 # if word occurs, increment its count

    dictionary_word_counts_ham = {word: 0 for word in vocab}
    for index, msg in enumerate(ham_train_set['TEXTMSG']):
        for word in msg:
            dictionary_word_counts_ham[word] += 1

    # p(spam) and p(ham)
    global p_spam
    global p_ham
    p_spam = len(spam_train_set) / len(train_set)
    # 0.13 - roughly 13% of messages in train set are spam
    p_ham = len(ham_train_set) / len(train_set) # 0.87
    # num words in spam
    num_words_per_spam_message = spam_train_set['TEXTMSG'].apply(len)
    num_words_spam = num_words_per_spam_message.sum() # total word count in spam messages
    # num words in ham
    num_words_per_ham_message = ham_train_set['TEXTMSG'].apply(len)
    num_words_ham = num_words_per_ham_message.sum() # total word count in ham messages
    # num words in vocab
    num_words_vocab = len(vocab)

    alpha = 2 # Laplace smoothing parameter

    global dictionary_probab_spam
    global dictionary_probab_ham
    dictionary_probab_spam = {word:0 for word in vocab} # initial p(word|spam) is 0
    dictionary_probab_ham = {word:0 for word in vocab} # initial p(word|ham) is 0
    # calculate p(wi|spam)
    for word in vocab:
        count_word_given_spam = dictionary_word_counts_spam[word] #
        p_word_given_spam = (count_word_given_spam + alpha) / (num_words_spam + alpha*num_words_vocab)
        dictionary_probab_spam[word] = p_word_given_spam

        count_word_given_ham = dictionary_word_counts_ham[word] #
        p_word_given_ham = (count_word_given_ham + alpha) / (num_words_ham + alpha*num_words_vocab)
        dictionary_probab_ham[word] = p_word_given_ham
    res = classify('WINNER!! This is the secret code to unlock the money: C3421.')
    print(res)
    res = classify('it was good to see you yesterday')
    print(res)
    res = classify('win win win click to see detail')
    print(res)
    # ------compute accuracy of test set ------
    test_set['predicted'] = test_set['TEXTMSG'].apply(classify)
    correct = 0
    total = test_set.shape[0]
    for row in test_set.iterrows():
        row = row[1]
        if row['Label'] == row['predicted']:
            correct += 1
    print('Correct:', correct)
    print('Incorrect:', total - correct)
    print('Accuracy:', correct/total)

if __name__ == "__main__":
    sys.exit(int(main() or 0))