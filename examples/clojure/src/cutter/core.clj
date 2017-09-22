(ns cutter.core
  (:require [cheshire.core :refer [parse-string]]))

(defn- input-data [] (parse-string (slurp "resources/data.json") true))

(def sum (partial reduce +))

(defn- cut [cuts size]
  (->> cuts
       (filter #(= size (:size %)))
       first
       :value))

(declare cut-for-highest-value-memo)

(defn cut-for-highest-value [cuts chunk]
  (let [sizes (map :size cuts)
        possible-cuts (filter #(<= % chunk) sizes)]
    (if (seq possible-cuts)
      (apply max (map #(+ (cut cuts %)
                          (cut-for-highest-value-memo cuts (- chunk %)))
                      possible-cuts))
      (- chunk))))

(def cut-for-highest-value-memo (memoize cut-for-highest-value))

(defn- cut-and-sum-chunks [{:keys [cuts rawChunks]}]
  (sum (pmap #(cut-for-highest-value-memo cuts %) rawChunks)))

(defn- cut-and-sum-all [data]
  (sum (map cut-and-sum-chunks (vals data))))

(defn solve []
  (cut-and-sum-all (input-data)))
